﻿using UnityEngine;
using System.Collections;

public class NPC_Talk : MonoBehaviour {

    public string[] LeaderTalk = new string[13];
    public string[] MerchantTalk = new string[13];
    public string[] Blacksmith = new string[13];

	void Start () {

        //LeaderTalk
        for (int i = 0; i < LeaderTalk.Length; i++)
        {           
            switch (i)
            {
                case 0:
                    {
                        LeaderTalk[i] = "\n\tสวัสดี,ข้ามีนามว่า เจฟ เป็นหัวหน้าหมู่บ้านของที่แห่งนี้ ตอนนี้ปราสาทใกล้ๆหมู่บ้านของเรากำลังโดนก๊อบบลินบุก " +
                            "และคาดว่าอีกไม่นานมันอาจจะบุกมายังหมู่บ้านของเราได้ เพื่อความปลอดภัยของเจ้า เจ้าควรหลบเลียงไปยังหมู่บ้านอื่นเพื่อความปลอดภัย..."+
                            "\n\n\tหะ...เจ้าว่าอย่างไรนะ เจ้าต้องการจะช่วยกำจัดกลิบบลินให้หมู่บ้านเราหรือ... แต่มันอันตรายมากเลยนะ เด็กหนุ่มอย่างเจ้า อย่าเอาชีวิตไปทิ้งเสียดีกว่า"+
                            "\n\n\tเฮ่ย~ หากเจ้าต้องการต้องการช่วยเราจริงๆ งันข้าขอทดสอบให้เจ้าไปกำจัดก็อบบลินบริเวณ ((เส้นทางสู่ปราสาท)) ดูก่อน แล้วระวังตัวดีๆล่ะ \n";
                        break;
                    }   
                case 2:
                    {
                        LeaderTalk[i] = "\n\tโอ้เจ้าสามารภทำมันได้สำเร็จจริงๆหรือนี่...  \n\n\tถ้างันข้าจะแนะนำให้เจ้าไปตามหา ลูน่า เธอจะช่วยเจ้าในเรื่องของยารักษาให้กับเจ้า"
                            + "\n\n\tเออ.. แล้วอย่าลืมนำของรางวัลจากข้าไปด้วยล่ะ มันจะช่วยให้เจ้ารอดตายจากเจ้าพวกก็อบบลินได้มากขึ้น โชคดี\n";
                        break;
                    }
                case 4:
                    {
                        LeaderTalk[i] = "\n\tต่อจากนี้ข้าจะให้เจ้าไปกำจัดพวกก็อบบลินบริเวณ ((เส้นทางสู่ปราสาท)) ให้สิ้นซาก มันคงไม่ยากไปสำหรับเจ้าหรอกนะพ่อหนุ่ม" +
                            "\n\n\tแล้วก็นี่เป็นยาที่ลูน่าฝากมาให้เจ้า ใช้มันให้คุ้มค่าล่ะ\n";
                        break;
                    }
                case 6:
                    {
                        LeaderTalk[i] = "\n\tฮ่าๆๆ นี่สินะที่เขาเรียกว่าความพยายามอยู่ที่ไหนความสำเร็จอยู่ที่นั่น เจ้าอาจจะเป็นผู้กล้าของหมู่บ้านนี้ก็เป็นได้ " +
                            "\n\n\tถ้าอย่างนี้เป็นอย่างไร ข้าจะให้เจ้าไปกำจัดเจ้าพวกก็บลินที่อยู๋ใน ((ปราสาทชั้นที่ 1)) หากเจ้าททำสำเร็จข้าก็มีของตอบแทนเล็กๆน้อยๆให้เจ้าเช่นเคย " +
                            "\n\n\tและนี่ของตอบแทนจากข้าสำหรับภารกิจก่อนหน้านี้\n";
                        break;
                    }
                case 8:
                    {
                        LeaderTalk[i] = "\n\tเจ้ากำจัดก็อบบลินในปราสาทชั้น 1 เรียบร้อยแล้วสินะ เป็นไปตามที่ข้าหวังไว้จริงๆ แต่ต่อจากนี้มันจะไม่ใช่เรื่องง่ายอย่างเช่นเคยอีกแล้ว" +
                            "เพราะต่อจากนี้เจ้าต้องต้องขึ้นไปยัง ((ปราสาทชั้นที่ 2)) ซึงเป็นที่อยู่ของราชาก็อบบลิน มันร้ายกาจกว่าก็อบบลินที่เจ้าเคยพบมาหลายเท่านัก จงระวังมันให้ดีอย่าได้ประมาทเชียวละ\n";
                        break;
                    }
                case 10:
                    {
                        LeaderTalk[i] = "\n\tว้าววว นี่เจ้าทำสำเร็จแล้วจริงๆ? เจ้าทำสำเร็จแล้วจริงๆสินะ เจ้าได้กำจัดราชาก็อบบลินที่แข็งแกร่งขนาดนั้นได้ ข้านั้นหวังไว้กับเจ้าไว้ แต่ไม่คิดว่าเจ้าจะทำ" +
                            "มันสำเร็จจริงๆ ต่อจากนี้พวกเราชาวหมู่บ้านคงไม่ต้องหาที่อยู่ใหม่ และเจ้าจะเป็นดังผู้กล้าในหมู่บ้านของเรา ขอบใจเจ้ามาก\n";
                        break;
                    }
                case 11:
                    {
                        LeaderTalk[i] = "\n\tสวัสดีท่านผู้กล้า..\n";
                        break;
                    }
                default:
                    {
                        LeaderTalk[i] = "\n\tโอ้.. ภารกิจมันคงยากไปสำหรับเจ้า แต่ไม่เป็นไรหากเจ้าไม่ไหวโปรดหลบไปที่ปลอดภัยเสีย\n";
                        break;
                    }


            }
        }
        
        //MerchantTalk
        for (int i = 0; i < MerchantTalk.Length; i++)
        {
            switch (i)
            {
                case 3:
                    {
                        MerchantTalk[i] = "\n\tสวัสดีข้าชื่อ ลูน่า.. ท่านพ่อแนะนำให้ท่านมาหาข้าหรือ? \n\n\tอ่าใช่ ข้าจะหายามาขายให้ท่าได้เสมอ แต่..ข้าต้องคิดเงินท่านนะ\n";
                        break;
                    }
                default:
                    {
                        MerchantTalk[i] = "\nหากท่านมีปัญหาเรื่องยารักษา ข้าสามารถช่วยเจ้าได้นะ\n";
                        break;
                    }

            }
        }
        
        //Blacksmith
        for (int i = 0; i < Blacksmith.Length; i++)
        {

            switch (i)
            {
                case 0:
                    {
                        Blacksmith[i] = "\nเจ้ามีปัญหาเรื่องตีเหล็กหรือ? ไว้ใจข้า รารอฟ ได้เลย\n";
                        break;
                    }
                default:
                    {
                        Blacksmith[i] = "\nเจ้ามีปัญหาเรื่องตีเหล็กหรือ? ไว้ใจข้า รารอฟ ได้เลย\n";
                        break;
                    }
            }
        }
	}
	
}
