using Practo_4;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Parcto_4
{
    class Program
    {
        static Dictionary<DateTime, List<Note>> notes = new Dictionary<DateTime, List<Note>>();
        static DateTime DateIndex = DateTime.Today;
        static int NoteIndex = 0;
        static bool ShowNote = false;

        static void Main(string[] args)
        {
            InitializeNotes();
            while (true)
            {
                Console.Clear();

                if (ShowNote)
                {
                    ShowNoteDetails(notes[DateIndex][NoteIndex]);
                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Tab)
                    {

                        ShowNote = false;
                    }
                }
                else
                {
                    ShowDate();
                    CheckNotes();
                    var key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            DateIndex = DateIndex.AddDays(-1);
                            NoteIndex = 0;
                            break;
                        case ConsoleKey.RightArrow:
                            DateIndex = DateIndex.AddDays(1);
                            NoteIndex = 0;
                            break;
                        case ConsoleKey.UpArrow:
                            if (NoteIndex > 0)
                                NoteIndex--;
                            break;
                        case ConsoleKey.DownArrow:
                            if (notes.ContainsKey(DateIndex) && NoteIndex < notes[DateIndex].Count - 1)
                                NoteIndex++;
                            break;
                        case ConsoleKey.Enter:
                            if (notes.ContainsKey(DateIndex) && notes[DateIndex].Count > 0)
                            {
                                ShowNote = true;
                            }
                            else
                            {
                                Console.WriteLine("Заметок нет."); // потом добавлю
                                Console.ReadKey();
                            }
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        static void InitializeNotes()
        {
            notes.Add(new DateTime(2023, 10, 18), new List<Note>
            {
                new Note("Test", "EJKFKJSKOFNSKDFNMKMDPKKKASDKPADKP"),
                new Note("Без чего нельзя жить", "Широта: -32.648319 Долгота: 149.547497")
            });

            notes.Add(new DateTime(2023, 10, 20), new List<Note>
            {
                new Note("Обучение", "Выбрать колледж(желательно не мпт)"),
                new Note("Итог", "Я поступил в мпт(((")
            });

            notes.Add(new DateTime(2023, 10, 21), new List<Note>
            {
                new Note("Заметка номер 5", "MAMA IA PROGRAMMIST HAHAHAHAAHAH")
            });
        }

        static void ShowDate()
        {
            Console.Write($"Текущая дата: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{DateIndex:dd.MM.yyyy}");
            Console.ResetColor();
            Console.WriteLine();
        }
        static void ShowNoteDetails(Note note)
        {
            Console.WriteLine($"Название: {note.Title}");
            Console.WriteLine($"Описание: {note.Description}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[!]");
            Console.ResetColor();
            Console.Write("Нажмите [Tab] для возврата..."); // БАРА-БАРА-БЕРЕ-БЕРЕ
        }

        static void CheckNotes()
        {
            if (notes.ContainsKey(DateIndex))
            {
                var noteList = notes[DateIndex];
                for (int i = 0; i < noteList.Count; i++)
                {
                    if (i == NoteIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("->");
                        Console.ResetColor();
                    }
                    else
                        Console.Write(" ");

                    Console.Write($"[{i + 1}] {noteList[i].Title}\n");
                }
            }
            else
            {
                Console.WriteLine("Заметок нет.");
            }
        }

    }
}
