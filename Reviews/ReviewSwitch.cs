using System;

public class ButtonClass
{
    //1. 이벤트 생성을 위한 대리자 생성
    public delegate void EventHandler();

    //2. 이벤트 선언: Click
    public event EventHandler Click;

    //3. 이벤트 발생 메서드: OnClick 이벤트 처리기(핸들러) 생성
    public void Onclick()
    {
        if (Click != null)
        {
            Click();
        }
    }
}

class EventDemo
{
    static void Main()
    {
        //a. Button 클래스의 인스턴스 생성
        ButtonClass btn = new ButtonClass();

        //b. btn 개체의 Click 이벤트에 실행할 메서드를 등록
        btn.Click += Hi1;
        btn.Click += Hi2;

        //c. 이벤트 처리기(발생 메서드)를 사용한 이벤트 발생: 다중 메서드 호출
        btn.Onclick();
    }

    static void Hi1() => Console.WriteLine($"C#");
    static void Hi2() => Console.WriteLine($".Net");
}