using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// 소숫점 문제

namespace Calculate
{
    public partial class Form1 : Form
    {
        string output; //최종 결과값p
        string cal;//사칙 연산 저장
        Double R;//사칙연산 후 결과 값

        //string[] cals= { };
        //string[] num;
        List<string> cals = new List<string>();
        List<string> number = new List<string>();



        public Form1()
        {

            InitializeComponent();
        }

        //공통 메서드 : 숫자버튼 클릭하여서 texbox 에 출력
        public void PrintResult(string x)
        {

            if (pre_Result.Text.Contains("="))
            {
                pre_Result.Clear();
                text_Result.Clear();
                
                cals.Clear();
            }



            //num 배열에 값 추가
            //num.Add(x);
            
            //text가 비어있지 않으면 추가
            if (text_Result.TextLength != 0)
            {   //초기값 일때는 제외
                if (text_Result.Text.Equals("0"))
                {
                    text_Result.Text = x;
                }
                else
                {
                    text_Result.AppendText(x);
                }

            }
            else  text_Result.Text = x;
        }


        //공통메서드 : 사칙연산버튼을 클릭하여서 위에 pre_Result textbox 에 출력
        public void PrintPreResult()
        {
            //계산이 완료된 것에 이어서 계산하면 결과값을 기준으로 연산 다시 시작
            if (pre_Result.Text.Contains("="))
            {

                pre_Result.Clear();
                pre_Result.Text = text_Result.Text;
                cals.Clear();
            }

            else
            {
                pre_Result.AppendText(text_Result.Text);

                int pre_str = pre_Result.TextLength;
                char last_pre_Result = pre_Result.Text[pre_str - 1]; //마지막 문자 

                //연산자는 연속사용 불가함으로, 다른 연산자를 선택하면 변경
                if (text_Result.TextLength != 1)
                {
                    switch (last_pre_Result)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            pre_Result.Text = pre_Result.Text.Substring(0, pre_str - 1); //마지막 연산 지우기
                            pre_Result.AppendText(text_Result.Text);

                            break;

                    }

                }
            }
            text_Result.Clear(); //연산에 사용된 상수 지우기 
        }

        //숫자 버튼 클릭 
        private void btn_num_1_Click(object sender, EventArgs e)
        {
            string num = btn_num_1.Text;
            PrintResult(num);
        }

        private void btn_num_2_Click(object sender, EventArgs e)
        {
            string num = btn_num_2.Text;
            PrintResult(num);
        }

        private void btn_num_3_Click(object sender, EventArgs e)
        {
            string num = btn_num_3.Text;
            PrintResult(num);
        }

        private void btn_num_4_Click(object sender, EventArgs e)
        {
            string num = btn_num_4.Text;
            PrintResult(num);
        }

        private void btn_num_5_Click(object sender, EventArgs e)
        {
            string num = btn_num_5.Text;
            PrintResult(num);
        }

        private void btn_num_6_Click(object sender, EventArgs e)
        {
            string num = btn_num_6.Text;
            PrintResult(num);
        }

        private void btn_num_7_Click(object sender, EventArgs e)
        {
            string num = btn_num_7.Text;
            PrintResult(num);
        }

        private void btn_num_8_Click(object sender, EventArgs e)
        {
            string num = btn_num_8.Text;
            PrintResult(num);
        }

        private void btn_num_9_Click(object sender, EventArgs e)
        {
            string num = btn_num_9.Text;
            PrintResult(num);
        }

        private void btn_num_0_Click(object sender, EventArgs e)
        {
            string num = btn_num_0.Text;
            PrintResult(num);
        }


        //CLEAR 현재 입력값을 0으로 초기화
        private void btn_clear_Click(object sender, EventArgs e)
        {
            text_Result.Clear();
            text_Result.Text = "0";
        }

        //문자열중에 마지막 숫자 지우기 
        private void btn_del_Click(object sender, EventArgs e)
        {
            int str = text_Result.TextLength; //현재 문자열 길이

            if (str == 1)
            {  //한자리 수면 0으로 초기화
                text_Result.Text = "0";
            }
            else
            {
                text_Result.Text = text_Result.Text.Substring(0, str - 1);
            }


        }
        //모든 것을 초기화
        private void btn_c_Click(object sender, EventArgs e)
        {
            text_Result.Clear();
            pre_Result.Clear();
            text_Result.Text = "0";

            number.Clear();
            cals.Clear();
        }
        //소수점 처리
        private void btn_dot_Click(object sender, EventArgs e)
        {
            //중복 체크
            if (text_Result.Text.Contains(".") == false)

                text_Result.Text += ".";
        }

        //양수 음수 처리 
        private void btn_plumin_Click(object sender, EventArgs e)
        {
            //문자열 정수로 변환
            int outNum = Convert.ToInt32(text_Result.Text);

            outNum = outNum * -1;

            //정수를 문자열로 변환
            string intNum = Convert.ToString(outNum);

            text_Result.Text = intNum;



        }

        //사칙연산 처리

        //덧셈
        private void btn_plus_Click(object sender, EventArgs e)
        {
            PrintPreResult();
            pre_Result.AppendText("+");

            cal = "plus";
            cals.Add(cal);

        }

        //뺄셈
        private void btn_minus_Click(object sender, EventArgs e)
        {
            PrintPreResult();
            pre_Result.AppendText("-");

            cal = "minus";
            cals.Add(cal);
        }
        //곱셈
        private void btn_mul_Click(object sender, EventArgs e)
        {
            PrintPreResult();
            pre_Result.AppendText("*");

            cal = "mul";
            cals.Add(cal);
        }

        //나눗셈
        private void btn_div_Click(object sender, EventArgs e)
        {
            PrintPreResult();
            pre_Result.AppendText("÷");

            cal = "div";
            cals.Add(cal);
        }

        // - 결과값 출력
        private void btn_equal_Click(object sender, EventArgs e)
        {


            //사칙연산 빼고 숫자만             
            //int len = pre_Result.TextLength;
            pre_Result.AppendText(text_Result.Text);

            //pre_Result 에서 split 으로 해서 짤라서 num에 숫자만 들어감

            string[] nums = pre_Result.Text.Split(new char[] { '+', '-', '*', '÷' });

            MessageBox.Show("%%%%" + nums[0] + nums[1] + nums[2]);
            number = nums.ToList();


            //초기값 S1 지정 
            string s1 = number[0];
            MessageBox.Show("~~~" +s1);
            Double R1 = Convert.ToDouble(s1);

            string s2;
            for (int i = 0; i < cals.Count; i++)
            {
                s2 = number[i + 1]; 
             
                cal = cals[i];

                //string을  Double로 변환    
                Double R2 = Convert.ToDouble(s2);


                //사칙연산하기 

                switch (cal)
                {
                    case "plus": R = R1 + R2; break; //더하기
                    case "minus": R = R1 - R2; break;//빼기
                    case "mul": R = R1 * R2; break;//곱셈
                    case "div": R = R1 / R2; break;//나눗셈

                }

                R1 = R;

            }

            output = R.ToString();

            //R 값이 정수이면 True, 실수이면 False
            if ((R % 1) == 1)
            {
                int int_R = (int)R;// int 로 형변환
                output = int_R.ToString();
            }
            else //실수 이면 바로 string으로 변환
            {
                output = R.ToString();
            }

            pre_Result.AppendText("=");
            //결과값 출력하기 
            text_Result.Text = output;
           

        }

    }



}
