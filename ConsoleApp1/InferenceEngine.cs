﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InferenceEngine
    {
        public KnowledgeBase kb;

        public InferenceEngine()
        {
            kb = new KnowledgeBase();
        }

        public void AddCancer(Cancer cancer)
        {
            kb.Cancers.Add(cancer);
        }

        public void AddSymptom(Symptom symptom)
        {
            kb.Symptoms.Add(symptom);
        }

        public void InferCancers(List<Symptom> symptoms) // forward chaining
        {
            // find which facts corresponds to a rule and create a temp list of rules that match
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < symptoms.Count; i++)
            {
                var match = FindMatch(symptoms[i]);

                if (match == null)
                {
                    // no match, continue to next iteration
                }
                else
                {
                    temp = temp.Union(match).ToList();
                }
            }

            Console.WriteLine("\nCancer types matched: ");
            for (int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine("Cancer " + (i + 1) + ": " + kb.Cancers[i].result.GetVariable());
            }
        }

        public List<Cancer> FindMatch(Symptom s)
        {
            List<Cancer> temp = new List<Cancer>();

            for (int i = 0; i < kb.Cancers.Count(); i++)
            {
                for (int j = 0; j < kb.Cancers[i].conditions.Count; j++)
                {
                    if (kb.Cancers[i].conditions[j].GetVariable().Trim().ToLower().Equals(s.symptom.GetVariable().Trim().ToLower()))
                    {
                        // matches, add to temp list
                        temp.Add(kb.Cancers[i]);
                    }
                    else
                    {
                        // does not match
                    }
                }
            }

            return temp;
        }

        public void ConditionWeighing(List<Cancer> cancer)
        {
            int result = 0;

            for (int i = 0; i < cancer.Count; i++)
            {
                var count = cancer[i].conditions.Count;
                result = 
            }
        }

        public void PrintCancers()
        {
            for (int i = 0; i < kb.Cancers.Count; i++)
            {
                Console.WriteLine("\nCancer " + (i + 1) + ": ");
                for (int j = 0; j < kb.Cancers[i].conditions.Count; j++)
                {
                    Console.WriteLine("Condition " + (j + 1) + ": " + kb.Cancers[i].conditions[j].GetVariable());
                }
                Console.WriteLine("Cancer type: " + kb.Cancers[i].result.GetVariable());
            }
        }

        public void PrintSymptoms()
        {
            Console.WriteLine("\nSymptoms count: " + kb.Symptoms.Count);

            for (int i = 0; i < kb.Symptoms.Count; i++)
            {
                Console.WriteLine("Symptom " + (i + 1) + ": " + kb.Symptoms[i].symptom.GetVariable() + "");
            }
        }
    }
}
