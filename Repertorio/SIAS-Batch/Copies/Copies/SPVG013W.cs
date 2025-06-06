using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class SPVG013W : VarBasis
    {
        /*"01  LK-VG013-TRACE                        PIC  X(001)*/
        public StringBasis LK_VG013_TRACE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  LK-VG013-SISTEMA-CHAMADOR             PIC  X(020)*/
        public StringBasis LK_VG013_SISTEMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"01  LK-VG013-CANAL                        PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_CANAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-ORIGEM                       PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-COD-USUARIO                  PIC  X(008)*/
        public StringBasis LK_VG013_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-VG013-TIPO-ACAO                    PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_TIPO_ACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-IDE-SISTEMA                  PIC  X(002)*/
        public StringBasis LK_VG013_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"01  LK-VG013-NUM-CERTIFICADO              PIC S9(018) COMP*/
        public IntBasis LK_VG013_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(018)"));
        /*"01  LK-VG013-COD-PRODUTO                  PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-COD-PLANO                    PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-QTD-TITULO                   PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_QTD_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-VLR-TITULO                   PIC S9(013)V9(002)                                                      COMP-3*/
        public DoubleBasis LK_VG013_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(002)"), 2);
        /*"01  LK-VG013-COD-EMPRESA-CAP              PIC S9(009) COMP-5*/
        public IntBasis LK_VG013_COD_EMPRESA_CAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-VG013-COD-RETORNO-API              PIC S9(004) COMP-5*/
        public IntBasis LK_VG013_COD_RETORNO_API { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-VG013-DES-ERRO                     PIC  X(255)*/
        public StringBasis LK_VG013_DES_ERRO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"01  LK-VG013-DES-ACAO                     PIC  X(255)*/
        public StringBasis LK_VG013_DES_ACAO { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
        /*"*/
    }
}