using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldGameController : MonoBehaviour
{
    public string[][] questions = new string[3][];
    public Sprite[][] sprites = new Sprite[3][];
    public string[][] trueAnswers = new string[3][];
    public string[,][] wrongAnswers = new string[3,3] []; //������ ����� ���������� ��������

    public Text textQuestion;
    public Image image;
    public Text textTrueAnswer;
    public Text textFalseAnswer_1;
    public Text textFalseAnswer_2;
    public Text textFalseAnswer_3;
    
  

    public Sprite[] sprites_1_Quests = new Sprite[3];
    public Sprite[] sprites_2_Quests = new Sprite[3];
    public Sprite[] sprites_3_Quests = new Sprite[3];

    
    private void Awake()
    {
        //questions
        questions[0] = new string[] { "��� ����� ����� ���������?",
        "��� ����� ����� ���������?",
        "��� ����� ����� ���������?"
        };
        questions[1] = new string[] { "����� ���������������� � ����� ���������?",
        "����� ���������������� � ����� ���������?",
        "����� ���������������� � ����� ���������?"
        };
        questions[2] = new string[] { "���� �������� ���������� �� ��������?",
        "���� �������� ���������� �� ��������?",
        "���� �������� ���������� �� ��������?"
        };
        // sprites
        sprites[0] = sprites_1_Quests;
        sprites[1] = sprites_2_Quests;
        sprites[2] = sprites_3_Quests;

        // ������ ������
        trueAnswers[0] = new string[] { "����������/�������",
        "������ ������",
        "����"
        };
        trueAnswers[1] = new string[] { "������",
        "������� ���",
        "���"
        };
        trueAnswers[2] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };

        //�������� ������ � 1 �������
        //������, ���������
     
        wrongAnswers[0,0] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        wrongAnswers[0,1] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        wrongAnswers[0,2] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        //�������� ������ �� 2 �������
        wrongAnswers[1,0] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        wrongAnswers[1,1] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        wrongAnswers[1,2] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        //�������� ������ � 3 �������
        wrongAnswers[2,0] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        wrongAnswers[2,1] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        wrongAnswers[2,2] = new string[] { "���",
        "��",
        "��, �� ������� �������"
        };
        
    }

    void Start()
    {
       // image.sprite =
    }

    void Update()
    {
        
    }


}
