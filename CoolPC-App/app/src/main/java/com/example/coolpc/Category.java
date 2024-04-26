package com.example.coolpc;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Category {
    @SerializedName("component_type_id")
    @Expose
    private long componentTypeId;
    @SerializedName("type")
    @Expose
    private String type;

    private int iconResource;

    public long getComponentTypeId() {
        return componentTypeId;
    }

    public void setComponentTypeId(long componentTypeId) {
        this.componentTypeId = componentTypeId;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public int getIconResource() {
        return iconResource;
    }

    public void setIconResource(int iconResource) {
        this.iconResource = iconResource;
    }

    public Category(long componentTypeId, String type, int iconResource) {
        this.componentTypeId = componentTypeId;
        this.type = type;
        this.iconResource = iconResource;
    }

    public Category() {

    }
}
