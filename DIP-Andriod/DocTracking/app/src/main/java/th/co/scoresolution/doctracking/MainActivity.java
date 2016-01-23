package th.co.scoresolution.doctracking;

import android.app.Activity;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Toast;

import java.io.File;
import java.util.Timer;
import java.util.TimerTask;


public class MainActivity extends ActionBarActivity {

    private WebView mWebview ;
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

        mWebview.loadUrl("http://192.168.1.101/dipuhf3_signage/frmSearchFilePositonByFile.aspx");
        setContentView(mWebview );


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

}
