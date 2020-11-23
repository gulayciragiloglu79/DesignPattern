using System;
using System.IO;
public interface Shape {
   double getArea();
}
public class Circle : Shape {
  private double radius;
  //@Override
  public double getArea() {
    return Math.PI*radius*radius;
  }
  //@Override
  public double getSize() {
    return 2*Math.PI*radius;
  }
  public void setRadius(double radius) {
    this.radius = radius;
  }
}

public class Rectangle : Shape {
 
   private double _height; 
   public double Height
   {
       get { return _height ; }
       set {
          this._height = value ;
       }
   }

   private double _lenght; 
   public double Lenght
   {
       get { return _lenght ; }
       set {
          this._lenght = value ;
       }
   }

   //@Override
   public double getArea() {
     return Height*Lenght;
   }
   //@Override
   public double getSize() {
    return 2*Height*Lenght;
   }
}
/**
* Abstract fabrika sinifimiz. Bu sinif süper fabrika sinifi
*/
public interface ShapeAbstractFactory {
   Shape createShape();
}
	/**
* Circle sinifi icin fabrika sinifi
*/
public class CircleFactory : ShapeAbstractFactory {
  //@Override
  public Shape createShape() {
     return new Circle();
  }
}

	/**
* Rectangle sinifi icin fabrika sinifi
*/
public class RectangleFactory : ShapeAbstractFactory {
  //@Override
  public Shape createShape() {
    return new Rectangle();
  }
}
/**
* Somut fabrika siniflarinin turune gore Shape nesneleri uretilmesini saglar
*/
public class ShapeFactory {
  public static Shape getShape(ShapeAbstractFactory factory){
    return factory.createShape();
  }
}

/**
* Test sinifi.
*/
public class TestFactory {
  public static void main(String[] args) {
    Shape rectangle = ShapeFactory.getShape(new RectangleFactory());
    ((Rectangle) rectangle).Height=13;
    ((Rectangle) rectangle).Lenght=5;
    Shape circle = ShapeFactory.getShape(new CircleFactory());
    ((Circle) circle).setRadius(4);
   
    /*Console.WriteLine("Rectangle area: "+rectangle.getArea()+" and size: "+rectangle.getSize());

   Console.WriteLine("Circle area: "+circle.getArea()+" and size: "+circle.getSize());*/
  }
}
