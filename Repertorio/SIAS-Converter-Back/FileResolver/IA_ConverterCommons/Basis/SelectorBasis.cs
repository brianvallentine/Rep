﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IA_ConverterCommons;
public class SelectorBasis : StructBasis<string>
{
    public SelectorBasis(string length = "01", string value = "") : base(new PIC("X", length, $"X({length})"), value) { }

    public List<SelectorItemBasis> Items { get; set; } = new List<SelectorItemBasis>();

    public bool this[string index]
    {
        get
        {
            var itm = Items.FirstOrDefault(x => x.Name == index);

            //correção para conter numero zero a esquerda
            var currVal = Value;
            var len = Pic.Length;

            var lstRet = itm?.Value?.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            if (lstRet.Last() == "ZEROS")
            {
                itm.Value = "0";
                lstRet = itm?.Value?.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();

            }
            if (itm?.Value?.Contains("THRU") == true)
            {
                var firstnum = 0;
                var lastnum = 0;

                Match match = Regex.Match(itm.Value, @"(\d+)\s+THRU\s+(\d+)");
                if (match.Success)
                {
                    firstnum = int.Parse(match.Groups[1].Value);
                    lastnum = int.Parse(match.Groups[2].Value);

                    int start = Math.Min(firstnum, lastnum);
                    int end = Math.Max(firstnum, lastnum);

                    lstRet.RemoveAll(x => x.Contains("THRU"));

                    lstRet.AddRange(Enumerable.Range(start, end - start + 1).Select(x => x.ToString()));
                }
            }
            return lstRet
                        .Any(x =>
                                    x.PadLeft(len, '0') == Value.Trim().PadLeft(len, '0')
                                    ||
                                    x.PadRight(len, ' ') == Value.Trim().PadRight(len, ' ')
                                    ||
                                    x.Trim() == Value.Trim()
                        ) == true;
        }
        set
        {
            var itm = Items.FirstOrDefault(x => x.Name == index);
            Value = itm?.Value;
        }
    }

    //public static bool operator ==(SelectorBasis basis, int comparacao)
    //{
    //    var isInt = int.TryParse(basis.GetMoveValues(), out var pBasis);
    //    return isInt ? pBasis == comparacao : false;
    //}

    //public static bool operator !=(SelectorBasis basis, int comparacao)
    //{
    //    var isInt = int.TryParse(basis.GetMoveValues(), out var pBasis);
    //    return isInt ? pBasis != comparacao : false;
    //}

    public static bool operator ==(SelectorBasis basis, string comparacao)
    {
        var greaterLen = comparacao.Length > basis.Value.Length ? comparacao.Length : basis.Value.Length;

        var leftZeroBasis = basis.Value.PadLeft(greaterLen, '0');
        var leftZeroComp = comparacao.PadLeft(greaterLen, '0');

        var rightSpaceBasis = basis.Value.PadRight(greaterLen, ' ');
        var rightSpaceComp = comparacao.PadRight(greaterLen, ' ');

        if (leftZeroBasis == leftZeroComp) return true;
        if (rightSpaceBasis == rightSpaceComp) return true;

        return false;
    }

    public static bool operator !=(SelectorBasis basis, string comparacao)
    {
        return !(basis == comparacao);
    }

    public new string ToString() => Value;
}

public class SelectorItemBasis
{
    public string Value { get; set; }
    public string Name { get; set; }
    public string Line { get; set; }

    public SelectorItemBasis(string name, string value, string line = null)
    {
        Value = value;
        Name = name;
        Line = line;
    }
}

//public class SelectorBasis : StructBasis<string>
//{
//    public SelectorBasis() : base(new PIC("X", "01"), "")
//    {
//    }

//    public List<SelectorItemBasis> Items { get; set; } = new List<SelectorItemBasis>();

//    public bool this[string index]
//    {
//        get
//        {
//            var itm = Items.FirstOrDefault(x => x.Name == index)?.Selected == true;
//            return itm;
//        }
//        set
//        {
//            foreach (var item in Items)
//            {
//                item.Selected = false;
//            }

//            var itm = Items.FirstOrDefault(x => x.Name == index);
//            itm.Selected = value;
//        }
//    }
//}

//public class SelectorItemBasis
//{
//    public bool Selected { get; set; }
//    public string Value { get; set; }
//    public string Name { get; set; }

//    public SelectorItemBasis(string name, string value)
//    {
//        Value = value;
//        Name = name;
//    }
//}
