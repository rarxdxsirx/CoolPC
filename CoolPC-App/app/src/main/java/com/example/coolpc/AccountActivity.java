package com.example.coolpc;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.widget.FrameLayout;
import android.widget.LinearLayout;
import android.widget.TextView;

public class AccountActivity extends AppCompatActivity {

    private static final String PREFS_FILE = "Account";
    private static final String PREFS_ID = "UserID";
    SharedPreferences settings;

    LinearLayout homeButton;
    LinearLayout cartButton;
    LinearLayout catalogButton;
    LinearLayout accountButton;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_account);

        settings = getSharedPreferences(PREFS_FILE, MODE_PRIVATE);

        FrameLayout navbar = findViewById(R.id.navbar);
        homeButton = navbar.findViewById(R.id.home);
        homeButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), HomeActivity.class);
            startActivity(intent);
            finish();
        });
        cartButton = navbar.findViewById(R.id.cart);
        cartButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), CartActivity.class);
            startActivity(intent);
            finish();
        });
        catalogButton = navbar.findViewById(R.id.catalog);
        catalogButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), CatalogActivity.class);
            startActivity(intent);
            finish();
        });
        accountButton = navbar.findViewById(R.id.account);
        accountButton.setOnClickListener(v -> {
            Intent intent = new Intent(getApplicationContext(), AccountActivity.class);
            startActivity(intent);
            finish();
        });

        TextView accountSettings = findViewById(R.id.account_settings);
        accountSettings.setOnClickListener(v -> {
            SharedPreferences.Editor prefEditor = settings.edit();
            prefEditor.clear();
            prefEditor.apply();
        });
    }
}