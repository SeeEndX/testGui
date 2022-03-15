package com.company;

public class Mammal extends Animal {
    private String name;
    private String eat;
    private int weight;
    private Boolean fur;

    public Mammal(String name, String eat, int weight, Boolean fur){
        this.name = name;
        this.eat = eat;
        this.weight = weight;
        this.fur=fur;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEat() {
        return eat;
    }

    public void setEat(String eat) {
        this.eat = eat;
    }

    public int getWeight() {
        return weight;
    }

    public void setWeight(int weight) {
        this.weight = weight;
    }

    public Boolean getFur() {
        return fur;
    }

    public void setFur(Boolean fur) {
        this.fur = fur;
    }
}
