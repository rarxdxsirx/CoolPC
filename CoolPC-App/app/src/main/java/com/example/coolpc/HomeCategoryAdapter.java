package com.example.coolpc;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

public class HomeCategoryAdapter extends RecyclerView.Adapter<HomeCategoryAdapter.ViewHolder> {

    private final LayoutInflater inflater;
    private final List<Category> categories;

    public HomeCategoryAdapter(Context context, List<Category> categories) {
        this.categories = categories;
        this.inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public HomeCategoryAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = inflater.inflate(R.layout.category_item,parent,false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull HomeCategoryAdapter.ViewHolder holder, int position) {
        Category category = categories.get(position);
        holder.categoryIcon.setImageResource(category.getIconResource());
        holder.categoryName.setText(category.getType());
    }

    @Override
    public int getItemCount() {
        return categories.size();
    }

    public static class ViewHolder extends RecyclerView.ViewHolder {
        final ImageView categoryIcon;
        final TextView categoryName;

        public ViewHolder(View view) {
            super(view);
            this.categoryIcon = view.findViewById(R.id.category_image);
            this.categoryName = view.findViewById(R.id.category_name);
        }
    }
}
