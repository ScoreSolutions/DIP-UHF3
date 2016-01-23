package th.co.scoresolution.dipsiagefault;

import android.app.Activity;
import android.app.ActivityManager;
import android.os.Bundle;
import android.os.Environment;
import android.os.StatFs;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.RandomAccessFile;
import java.net.HttpURLConnection;
import java.net.InetAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.URL;
import java.net.URLConnection;
import java.util.Enumeration;
import java.util.Timer;
import java.util.TimerTask;



public class MainActivity extends ActionBarActivity {

    private WebView mWebview ;
    private WebView mWebviewRAM ;
    private Timer t;
    private int TimeCounter = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // setContentView(R.layout.activity_main);

        //แสดงเต็มจอ
        View decorView = getWindow().getDecorView();
        int uiOptions = View.SYSTEM_UI_FLAG_HIDE_NAVIGATION
                | View.SYSTEM_UI_FLAG_FULLSCREEN;
        decorView.setSystemUiVisibility(uiOptions);
        //สร้าง control เพื่อใช้แสดงเว็บ
        mWebview  = new WebView(this);

        final Activity activity = this;

        mWebview.getSettings().setJavaScriptEnabled(true); // enable javascript

        mWebview.setWebViewClient(new WebViewClient() {
            public void onReceivedError(WebView view, int errorCode, String description, String failingUrl) {
                Toast.makeText(activity, description, Toast.LENGTH_SHORT).show();
            }
        });



        // mWebview.loadUrl("http://192.168.1.88:8080/DIPUHF3_Signage/Signage.aspx");
        // setContentView(mWebview );

        //readRAM();
        // Connection connection = new Connection("http://192.168.1.88:8080/DIPWebFaultMng/FaultMngService.aspx?MethodName=SendCPUInfo&DeviceName=ReaderName&IPAddress=192.168.1.21&MacAddress=001AD580FF&CPUPercent=5");
        //connection.setMethod(Connection.POST_METHOD);
        // connection.setDelayed(0);
        // connection.setOnConnectionCallBackListener(this);
        // connection.execute();

        // System.out.println("HD :"+ readUsage());

        readRAM();
        readHD();
        readUsage();

        //timer แสดงทุก 1 นาที
        t = new Timer();
        t.scheduleAtFixedRate(new TimerTask() {



            @Override
            public void run() {
                // TODO Auto-generated method stub
                runOnUiThread(new Runnable() {
                    public void run() {

                        //clear
                        clearApplicationData();

                       readRAM();
                       readHD();
                       readUsage();



                        //mWebview.loadUrl("http://192.168.1.35/dip3_signage/signage.aspx");
                        //setContentView(mWebview );



                        //TimeCounter++;
                    }
                });

            }
        }, 3000, 60000); // 1000 means start from 1 sec, and the second 1000 is do the loop each 1 sec.
        //getSupportActionBar().setDisplayShowTitleEnabled(false);
        //getSupportActionBar().setDisplayShowHomeEnabled(false);
    }

    public void clearApplicationData() {
        File cache = getCacheDir();
        File appDir = new File(cache.getParent());
        if(appDir.exists()){
            String[] children = appDir.list();
            for(String s : children){
                if(!s.equals("lib")){
                    deleteDir(new File(appDir, s));
                    //  Log.i("TAG", "**************** File /data/data/APP_PACKAGE/" + s + " DELETED *******************");
                }
            }
        }
    }

    public static boolean deleteDir(File dir) {
        if (dir != null && dir.isDirectory()) {
            String[] children = dir.list();
            for (int i = 0; i < children.length; i++) {
                boolean success = deleteDir(new File(dir, children[i]));
                if (!success) {
                    return false;
                }
            }
        }


        return dir.delete();
    }





    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private void readUsage() {
        try {
            RandomAccessFile reader = new RandomAccessFile("/proc/stat", "r");
            String load = reader.readLine();

            String[] toks = load.split(" +");  // Split on one or more spaces

            long idle1 = Long.parseLong(toks[4]);
            long cpu1 = Long.parseLong(toks[2]) + Long.parseLong(toks[3]) + Long.parseLong(toks[5])
                    + Long.parseLong(toks[6]) + Long.parseLong(toks[7]) + Long.parseLong(toks[8]);

            try {
                Thread.sleep(360);
            } catch (Exception e) {}

            reader.seek(0);
            load = reader.readLine();
            reader.close();

            toks = load.split(" +");

            long idle2 = Long.parseLong(toks[4]);
            long cpu2 = Long.parseLong(toks[2]) + Long.parseLong(toks[3]) + Long.parseLong(toks[5])
                    + Long.parseLong(toks[6]) + Long.parseLong(toks[7]) + Long.parseLong(toks[8]);
          //  float percentcpuold = (float)(cpu2 - cpu1)  / ((cpu2 + idle2) - (cpu1 + idle1));
            float percentcpu =(float)(cpu1 * 100)/(float)(cpu1 + idle1) ;

            //String strIP =getIP();
           // String strMAC = getMac();
            String url;
            String strIP ="192.168.1.22";//getIP();
            String strMAC = "00CE39BD4E6E";//getMac();
            String strDevice = "Signage5";
            String strSN = "Signage5";

            url  ="http://10.10.18.88:8080/DIPWebFaultMng/FaultMngService.aspx?MethodName=SendCPUInfo&DeviceName=" + strDevice + "&IPAddress=" + strIP + "&MacAddress=" + strMAC + "&CPUPercent=" + String.valueOf(percentcpu) + "&SN=" + strSN;

            mWebview  = new WebView(this);
            mWebview.loadUrl(url);

            //CallURL(url);
            // return percentcpu;

        } catch (IOException ex) {
            ex.printStackTrace();
        }

        // return 0;
    }

    private String getIP(){

        String ipAddress = null;
        try {
            for (Enumeration<NetworkInterface> en = NetworkInterface.getNetworkInterfaces(); en.hasMoreElements();) {
                NetworkInterface intf = en.nextElement();
                for (Enumeration<InetAddress> enumIpAddr = intf.getInetAddresses(); enumIpAddr.hasMoreElements();) {
                    InetAddress inetAddress = enumIpAddr.nextElement();
                    if (!inetAddress.isLoopbackAddress()) {
                        ipAddress = inetAddress.getHostAddress().toString();
                    }
                }
            }
        } catch (SocketException ex) {

        }

        return ipAddress;
    }

    private void readRAM(){
        try {

            ActivityManager.MemoryInfo mi = new ActivityManager.MemoryInfo();
            ActivityManager activityManager = (ActivityManager) getSystemService(ACTIVITY_SERVICE);
            activityManager.getMemoryInfo(mi);
            long availableMegs = mi.availMem / 1048576L;

//Percentage can be calculated for API 16+
            long percentAvail = (mi.availMem * 100) / mi.totalMem;

            String strIP ="192.168.1.22";//getIP();
            String strMAC = "00CE39BD4E6E";//getMac();
            String strDevice = "Signage5";
            String strSN = "Signage5";
            String url;
            url  ="http://10.10.18.88:8080/DIPWebFaultMng/FaultMngService.aspx?MethodName=SendRAMInfo&DeviceName=" + strDevice + "&IPAddress=" + strIP + "&MacAddress=" + strMAC + "&RAMPercent=" + String.valueOf(percentAvail) + "&SN=" + strSN;

            // mWebview.loadUrl(url);
            // setContentView(mWebview);

            mWebview  = new WebView(this);
            mWebview.loadUrl(url);
            //  setContentView(mWebviewRAM);
            // CallURL("http://localhost:2522/POST.aspx");
            // CallURL("http://localhost:2522/POST.aspx");
            // return  percentAvail;

        } catch (Exception e) {
            //return  0;
        }

    }

    private String getMac()
    {
        StringBuffer fileData = new StringBuffer(1000);
        try {
            BufferedReader reader = new BufferedReader(new FileReader("/sys/class/net/eth0/address"));
            char[] buf = new char[1024];
            int numRead = 0;
            while ((numRead = reader.read(buf)) != -1) {
                String readData = String.valueOf(buf, 0, numRead);
                fileData.append(readData);
            }
            reader.close();
            return fileData.toString();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }
    @SuppressWarnings("deprecation")
    private void readHD(){
        try{
            //StatFs stat = new StatFs(Environment.getExternalStorageDirectory().getPath());
            // long bytessizei = (long)stat.getAvailableBlocks();
            //long bytescounti = stat.getAvailableBytes();
            // long bytescounttotal = (long)stat.getFreeBlocks();
            // long bytesAvailable = (long)stat.getBlockSize() * (long)stat.getBlockCount();
            // long megAvailable = bytesAvailable / 1048576;
            // System.out.println("Megs :"+megAvailable);
            //  return  megAvailable;

            File path = Environment.getDataDirectory();
            StatFs stat = new StatFs(path.getPath());


            long blockSize;
            long totalSize;
            long availableSize;
            long percent;
                try{
                     blockSize = stat.getBlockSize();
                     totalSize =(( stat.getBlockCount()*blockSize) / 1073741824);
                     availableSize =(( stat.getAvailableBlocks()*blockSize) / 1073741824);


                   // final Context context = this;
                   // AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
                   // alertDialog.setTitle("blockSize:" + String.valueOf(blockSize) + "|totalSize:" + String.valueOf(totalSize) + "|availableSize:" + String.valueOf(availableSize));
                   // alertDialog.setMessage("blockSize:" + String.valueOf(blockSize) + "|totalSize:" + String.valueOf(totalSize) + "|availableSize:" + String.valueOf(availableSize));

                   // AlertDialog alertDialog2 = alertDialog.create();

                   // alertDialog2.show();

                   // long freeBytesInternal = new File(path.getFilesDir().getAbsoluteFile().toString()).getFreeSpace();
                   // long freeBytesExternal = new File(getExternalFilesDir(null).toString()).getFreeSpace();
                    if (totalSize == 0){
                        totalSize = (long)0.99;
                        availableSize = (long)0.34;
                      }



                    if (totalSize !=0){
                        percent = 100 - ((availableSize * 100)/totalSize);
                    }else{
                        percent = 0;
                    }

                }catch (Exception e){

                   // final Context context = this;
                   // AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
                   // alertDialog.setTitle(e.toString());
                   // alertDialog.setMessage(e.toString());

                   // AlertDialog alertDialog2 = alertDialog.create();

                   // alertDialog2.show();

                    blockSize= 0;
                    totalSize= 0;
                    availableSize= 0;
                    percent= 0;
                }
            //String strIP =getIP();
           // String strMAC = getMac();
            String url;
            String strIP ="192.168.1.22";//getIP();
            String strMAC = "00CE39BD4E6E";//getMac();
            String strDevice = "Signage5";
            String strSN = "Signage5";

            url  ="http://10.10.18.88:8080/DIPWebFaultMng/FaultMngService.aspx?MethodName=SendDriveInfo&DeviceName=" + strDevice + "&IPAddress=" + strIP + "&MacAddress=" + strMAC + "&DriveFreeSpace=" + String.valueOf((availableSize)) + "&DriveTotalSize=" + String.valueOf((totalSize)) + "&DrivePercent=" + String.valueOf((percent)) + "&DrivePath=root" + "&SN=" + strSN;

            mWebview  = new WebView(this);
            mWebview.loadUrl(url);



            //CallURL(url);
            // return percent;

        } catch (Exception e) {
            //   return  0;
        }
    }

    private void CallURL(String strURL){

        URL url;
        HttpURLConnection urlConnection = null;
        try {
            url = new URL(strURL);

            urlConnection = (HttpURLConnection) url
                    .openConnection();

            urlConnection.setRequestMethod("POST");

            urlConnection.setDoOutput(true);
            urlConnection.setRequestProperty ("Authorization", "");

            OutputStreamWriter writer = new OutputStreamWriter(urlConnection.getOutputStream());

            InputStream in = urlConnection.getInputStream();

            InputStreamReader isw = new InputStreamReader(in);

            int data = isw.read();
            while (data != -1) {
                char current = (char) data;
                data = isw.read();
                System.out.print(current);
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                urlConnection.disconnect();
            } catch (Exception e) {
                e.printStackTrace(); //If you want further info on failure...
            }
        }
    }

    public static String get(String url) throws IOException {

        ByteArrayOutputStream os = new ByteArrayOutputStream();
        URLConnection conn=null;
        byte[] buf = new byte[4096];

        try {
            URL a = new URL(url);

            conn = a.openConnection();
            // conn.setRequestProperty("User-Agent", "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.4; en-US; rv:1.9.2.2) Gecko/20100316 Firefox/3.6.2");

            // HttpURLConnection conn2 =conn.openConnection();
            // conn2.setRequestMethod("POST");

            InputStream is = conn.getInputStream();
            int ret = 0;
            while ((ret = is.read(buf)) > 0) {
                os.write(buf, 0, ret);
            }
            // close the inputstream
            is.close();
            return new String(os.toByteArray());
        } catch (IOException e) {
            try {
                int respCode = ((HttpURLConnection)conn).getResponseCode();
                InputStream es = ((HttpURLConnection)conn).getErrorStream();
                int ret = 0;
                // read the response body
                while ((ret = es.read(buf)) > 0) {
                    os.write(buf, 0, ret);
                }
                // close the errorstream
                es.close();
                return "Error response " + respCode + ": " +
                        new String(os.toByteArray());
            } catch(IOException ex) {
                throw ex;
            }
        }
    }
}
