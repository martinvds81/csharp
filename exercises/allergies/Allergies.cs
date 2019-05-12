using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private Allergen Mask { get; }

    public Allergies(int mask) => Mask = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen) => Mask.HasFlag(allergen);

    public Allergen[] List()
    {
        return Enum.GetValues(typeof(Allergen))
             .Cast<Allergen>()
             .Where(a => IsAllergicTo(a))
             .ToArray();
    }
}