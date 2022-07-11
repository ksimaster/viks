using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldGameController : MonoBehaviour
{
    public string[][] questions = new string[3][];
    public Sprite[][] sprites = new Sprite[3][];
    public string[][] trueAnswers = new string[3][];
    public string[,][] wrongAnswers = new string[3,3] []; //первая цифра количество вопросов

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
        questions[0] = new string[] { "Как зовут этого персонажа?",
        "Как зовут этого персонажа?",
        "Как зовут этого персонажа?"
        };
        questions[1] = new string[] { "Какая суперспособность у этого персонажа?",
        "Какая суперспособность у этого персонажа?",
        "Какая суперспособность у этого персонажа?"
        };
        questions[2] = new string[] { "Этот персонаж встречался со Старлайт?",
        "Этот персонаж встречался со Старлайт?",
        "Этот персонаж встречался со Старлайт?"
        };
        // sprites
        sprites[0] = sprites_1_Quests;
        sprites[1] = sprites_2_Quests;
        sprites[2] = sprites_3_Quests;

        // верные ответы
        trueAnswers[0] = new string[] { "Хоумлендер/Патриот",
        "Уильям Бутчер",
        "Хьюи"
        };
        trueAnswers[1] = new string[] { "Летать",
        "Быстрый бег",
        "Уме"
        };
        trueAnswers[2] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };

        //неверные ответы к 1 вопросу
        //ошибка, проверить
     
        wrongAnswers[0,0] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        wrongAnswers[0,1] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        wrongAnswers[0,2] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        //неверные ответы ко 2 вопросу
        wrongAnswers[1,0] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        wrongAnswers[1,1] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        wrongAnswers[1,2] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        //неверные ответы к 3 вопросу
        wrongAnswers[2,0] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        wrongAnswers[2,1] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
        };
        wrongAnswers[2,2] = new string[] { "Нет",
        "Да",
        "Да, до событий сериала"
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
