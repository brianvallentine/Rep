using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class VG036_DCLVG_PLANO_ACESSORIO : VarBasis
    {
        /*"    10 VG036-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG036_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG036-CODSUBES       PIC S9(4) USAGE COMP.*/
        public IntBasis VG036_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG036-OPCAO-COBER    PIC X(1).*/
        public StringBasis VG036_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG036-DTINIVIG       PIC X(10).*/
        public StringBasis VG036_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG036-IDADE-INICIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis VG036_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG036-IDADE-FINAL    PIC S9(4) USAGE COMP.*/
        public IntBasis VG036_IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG036-PERIPGTO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG036_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG036-DTTERVIG       PIC X(10).*/
        public StringBasis VG036_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG036-NUM-ACESSORIO  PIC S9(4) USAGE COMP.*/
        public IntBasis VG036_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG036-QTD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VG036_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG036-VLR-IMP-SEGURADA       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG036_VLR_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG036-VLR-CUSTO      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG036_VLR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG036-VLR-PREMIO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG036_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG036-VLR-TAXA       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis VG036_VLR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"*/
    }
}