package com.example.coolpc;

import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintSet;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.text.Layout;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.LinearLayout;

import java.util.ArrayList;

public class HomeActivity extends AppCompatActivity {

    LinearLayout homeButton;
    LinearLayout cartButton;
    LinearLayout catalogButton;
    LinearLayout accountButton;
    ArrayList<Category> categoryArrayList = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

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

        setInitialData();

        RecyclerView categoryRecyclerView = findViewById(R.id.catalogRecyclerView);
        HomeCategoryAdapter adapter = new HomeCategoryAdapter(this,categoryArrayList);
        categoryRecyclerView.setAdapter(adapter);
        categoryRecyclerView.setLayoutManager(new LinearLayoutManager(getApplicationContext(), LinearLayoutManager.HORIZONTAL, false));

    }

    private void setInitialData() {
        categoryArrayList.add(new Category(1,"Клавиатуры",R.drawable.test_keyboard_icon));
        categoryArrayList.add(new Category(2,"Мониторы",R.drawable.test_mono_icon));
        categoryArrayList.add(new Category(3,"Блоки",R.drawable.test_pc_icon));
        categoryArrayList.add(new Category(4,"Мыши",R.drawable.test_mouse_icon));
    }
}