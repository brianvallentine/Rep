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
    public class JVBKINCL_JV_PRODUTOS : VarBasis
    {
        /*"  02  JVPRD3701A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 3700 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD3701A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 3700);
        /*"  02  JVPRD3701                    PIC S9(004) COMP-5 VALUE 3721*/
        public IntBasis JVPRD3701 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3721);
        /*"  02  JVPRD3702                    PIC S9(004) COMP-5 VALUE 3722*/
        public IntBasis JVPRD3702 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3722);
        /*"  02  JVPRD3703                    PIC S9(004) COMP-5 VALUE 3723*/
        public IntBasis JVPRD3703 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3723);
        /*"  02  JVPRD3709A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0005 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD3709A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0005);
        /*"  02  JVPRD3709                    PIC S9(004) COMP-5 VALUE 3724*/
        public IntBasis JVPRD3709 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3724);
        /*"  02  JVPRD3716A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0006 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD3716A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0006);
        /*"  02  JVPRD3716                    PIC S9(004) COMP-5 VALUE 3725*/
        public IntBasis JVPRD3716 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 3725);
        /*"  02  JVPRD6901A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 3184 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD6901A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 3184);
        /*"  02  JVPRD6901                    PIC S9(004) COMP-5 VALUE 6931*/
        public IntBasis JVPRD6901 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6931);
        /*"  02  JVPRD6902                    PIC S9(004) COMP-5 VALUE 6932*/
        public IntBasis JVPRD6902 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6932);
        /*"  02  JVPRD6903                    PIC S9(004) COMP-5 VALUE 6933*/
        public IntBasis JVPRD6903 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6933);
        /*"  02  JVPRD6904                    PIC S9(004) COMP-5 VALUE 6934*/
        public IntBasis JVPRD6904 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6934);
        /*"  02  JVPRD6905                    PIC S9(004) COMP-5 VALUE 6935*/
        public IntBasis JVPRD6905 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6935);
        /*"  02  JVPRD6906                    PIC S9(004) COMP-5 VALUE 6936*/
        public IntBasis JVPRD6906 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6936);
        /*"  02  JVPRD6907                    PIC S9(004) COMP-5 VALUE 6937*/
        public IntBasis JVPRD6907 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6937);
        /*"  02  JVPRD6908                    PIC S9(004) COMP-5 VALUE 6938*/
        public IntBasis JVPRD6908 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6938);
        /*"  02  JVPRD6909                    PIC S9(004) COMP-5 VALUE 6939*/
        public IntBasis JVPRD6909 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6939);
        /*"  02  JVPRD6910                    PIC S9(004) COMP-5 VALUE 6940*/
        public IntBasis JVPRD6910 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6940);
        /*"  02  JVPRD6911                    PIC S9(004) COMP-5 VALUE 6941*/
        public IntBasis JVPRD6911 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6941);
        /*"  02  JVPRD6912                    PIC S9(004) COMP-5 VALUE 6942*/
        public IntBasis JVPRD6912 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6942);
        /*"  02  JVPRD6913                    PIC S9(004) COMP-5 VALUE 6943*/
        public IntBasis JVPRD6913 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6943);
        /*"  02  JVPRD6914                    PIC S9(004) COMP-5 VALUE 6944*/
        public IntBasis JVPRD6914 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6944);
        /*"  02  JVPRD6915                    PIC S9(004) COMP-5 VALUE 6945*/
        public IntBasis JVPRD6915 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6945);
        /*"  02  JVPRD6916                    PIC S9(004) COMP-5 VALUE 6946*/
        public IntBasis JVPRD6916 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 6946);
        /*"  02  JVPRD7705A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 788*/
        public ListBasis<IntBasis, Int64> JVPRD7705A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 788);
        /*"  02  JVPRD7705                    PIC S9(004) COMP-5 VALUE 7761*/
        public IntBasis JVPRD7705 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7761);
        /*"  02  JVPRD7711A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS   5*/
        public ListBasis<IntBasis, Int64> JVPRD7711A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 5);
        /*"  02  JVPRD7711                    PIC S9(004) COMP-5 VALUE 7768*/
        public IntBasis JVPRD7711 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7768);
        /*"  02  JVPRD7712                    PIC S9(004) COMP-5 VALUE 7771*/
        public IntBasis JVPRD7712 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7771);
        /*"  02  JVPRD7716A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS   3*/
        public ListBasis<IntBasis, Int64> JVPRD7716A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 3);
        /*"  02  JVPRD7716                    PIC S9(004) COMP-5 VALUE 7762*/
        public IntBasis JVPRD7716 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7762);
        /*"  02  JVPRD7725A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS   8*/
        public ListBasis<IntBasis, Int64> JVPRD7725A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 8);
        /*"  02  JVPRD7725                    PIC S9(004) COMP-5 VALUE 7742*/
        public IntBasis JVPRD7725 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7742);
        /*"  02  JVPRD7730A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS   4*/
        public ListBasis<IntBasis, Int64> JVPRD7730A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 4);
        /*"  02  JVPRD7730                    PIC S9(004) COMP-5 VALUE 7765*/
        public IntBasis JVPRD7730 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7765);
        /*"  02  JVPRD7731                    PIC S9(004) COMP-5 VALUE 7766*/
        public IntBasis JVPRD7731 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7766);
        /*"  02  JVPRD7732                    PIC S9(004) COMP-5 VALUE 7763*/
        public IntBasis JVPRD7732 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7763);
        /*"  02  JVPRD7733                    PIC S9(004) COMP-5 VALUE 7743*/
        public IntBasis JVPRD7733 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7743);
        /*"  02  JVPRD7734                    PIC S9(004) COMP-5 VALUE 7745*/
        public IntBasis JVPRD7734 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7745);
        /*"  02  JVPRD7735                    PIC S9(004) COMP-5 VALUE 7746*/
        public IntBasis JVPRD7735 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7746);
        /*"  02  JVPRD7736                    PIC S9(004) COMP-5 VALUE 7769*/
        public IntBasis JVPRD7736 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7769);
        /*"  02  JVPRD7737                    PIC S9(004) COMP-5 VALUE 7741*/
        public IntBasis JVPRD7737 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7741);
        /*"  02  JVPRD7738                    PIC S9(004) COMP-5 VALUE 7770*/
        public IntBasis JVPRD7738 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 7770);
        /*"  02  JVPRD8114A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0375 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD8114A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0375);
        /*"  02  JVPRD8114                    PIC S9(004) COMP-5 VALUE 8519*/
        public IntBasis JVPRD8114 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8519);
        /*"  02  JVPRD8115                    PIC S9(004) COMP-5 VALUE 8516*/
        public IntBasis JVPRD8115 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8516);
        /*"  02  JVPRD8116                    PIC S9(004) COMP-5 VALUE 8517*/
        public IntBasis JVPRD8116 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8517);
        /*"  02  JVPRD8117                    PIC S9(004) COMP-5 VALUE 8520*/
        public IntBasis JVPRD8117 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8520);
        /*"  02  JVPRD8118                    PIC S9(004) COMP-5 VALUE 8518*/
        public IntBasis JVPRD8118 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8518);
        /*"  02  JVPRD8119                    PIC S9(004) COMP-5 VALUE 8513*/
        public IntBasis JVPRD8119 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8513);
        /*"  02  JVPRD8120                    PIC S9(004) COMP-5 VALUE 8511*/
        public IntBasis JVPRD8120 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8511);
        /*"  02  JVPRD8121                    PIC S9(004) COMP-5 VALUE 8512*/
        public IntBasis JVPRD8121 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8512);
        /*"  02  JVPRD8122                    PIC S9(004) COMP-5 VALUE 8514*/
        public IntBasis JVPRD8122 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8514);
        /*"  02  JVPRD8123                    PIC S9(004) COMP-5 VALUE 8515*/
        public IntBasis JVPRD8123 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8515);
        /*"  02  JVPRD8144A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0020 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD8144A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0020);
        /*"  02  JVPRD8144                    PIC S9(004) COMP-5 VALUE 8521*/
        public IntBasis JVPRD8144 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8521);
        /*"  02  JVPRD8145                    PIC S9(004) COMP-5 VALUE 8526*/
        public IntBasis JVPRD8145 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8526);
        /*"  02  JVPRD8146                    PIC S9(004) COMP-5 VALUE 8524*/
        public IntBasis JVPRD8146 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8524);
        /*"  02  JVPRD8147                    PIC S9(004) COMP-5 VALUE 8525*/
        public IntBasis JVPRD8147 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8525);
        /*"  02  JVPRD8148                    PIC S9(004) COMP-5 VALUE 8527*/
        public IntBasis JVPRD8148 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8527);
        /*"  02  JVPRD8149                    PIC S9(004) COMP-5 VALUE 8523*/
        public IntBasis JVPRD8149 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8523);
        /*"  02  JVPRD8150                    PIC S9(004) COMP-5 VALUE 8522*/
        public IntBasis JVPRD8150 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8522);
        /*"  02  JVPRD8203A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0052 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD8203A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0052);
        /*"  02  JVPRD8203                    PIC S9(004) COMP-5 VALUE 8246*/
        public IntBasis JVPRD8203 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8246);
        /*"  02  JVPRD8204A                   PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis JVPRD8204A { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  02  JVPRD8205                    PIC S9(004) COMP-5 VALUE 8241*/
        public IntBasis JVPRD8205 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8241);
        /*"  02  JVPRD8206                    PIC S9(004) COMP-5 VALUE 8247*/
        public IntBasis JVPRD8206 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8247);
        /*"  02  JVPRD8209A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0002 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD8209A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0002);
        /*"  02  JVPRD8209                    PIC S9(004) COMP-5 VALUE 8242*/
        public IntBasis JVPRD8209 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8242);
        /*"  02  JVPRD8214A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0004 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD8214A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0004);
        /*"  02  JVPRD8214                    PIC S9(004) COMP-5 VALUE 8248*/
        public IntBasis JVPRD8214 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 8248);
        /*"  02  JVPRD9310A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 1095 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9310A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 1095);
        /*"  02  JVPRD9310                    PIC S9(004) COMP-5 VALUE 9749*/
        public IntBasis JVPRD9310 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9749);
        /*"  02  JVPRD9311                    PIC S9(004) COMP-5 VALUE 9386*/
        public IntBasis JVPRD9311 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9386);
        /*"  02  JVPRD9314A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0002 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9314A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0002);
        /*"  02  JVPRD9314                    PIC S9(004) COMP-5 VALUE 9729*/
        public IntBasis JVPRD9314 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9729);
        /*"  02  JVPRD9320A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0005 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9320A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0005);
        /*"  02  JVPRD9320                    PIC S9(004) COMP-5 VALUE 9741*/
        public IntBasis JVPRD9320 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9741);
        /*"  02  JVPRD9321                    PIC S9(004) COMP-5 VALUE 9742*/
        public IntBasis JVPRD9321 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9742);
        /*"  02  JVPRD9327A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0005 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9327A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0005);
        /*"  02  JVPRD9327                    PIC S9(004) COMP-5 VALUE 9731*/
        public IntBasis JVPRD9327 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9731);
        /*"  02  JVPRD9328                    PIC S9(004) COMP-5 VALUE 9732*/
        public IntBasis JVPRD9328 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9732);
        /*"  02  JVPRD9329                    PIC S9(004) COMP-5 VALUE 9381*/
        public IntBasis JVPRD9329 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9381);
        /*"  02  JVPRD9330                    PIC S9(004) COMP-5 VALUE 9387*/
        public IntBasis JVPRD9330 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9387);
        /*"  02  JVPRD9332A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0001 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9332A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0001);
        /*"  02  JVPRD9332                    PIC S9(004) COMP-5 VALUE 9743*/
        public IntBasis JVPRD9332 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9743);
        /*"  02  JVPRD9334A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0001 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9334A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0001);
        /*"  02  JVPRD9334                    PIC S9(004) COMP-5 VALUE 9733*/
        public IntBasis JVPRD9334 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9733);
        /*"  02  JVPRD9343A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0008 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9343A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0008);
        /*"  02  JVPRD9343                    PIC S9(004) COMP-5 VALUE 9382*/
        public IntBasis JVPRD9343 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9382);
        /*"  02  JVPRD9351A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0007 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9351A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0007);
        /*"  02  JVPRD9351                    PIC S9(004) COMP-5 VALUE 9723*/
        public IntBasis JVPRD9351 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9723);
        /*"  02  JVPRD9352                    PIC S9(004) COMP-5 VALUE 9722*/
        public IntBasis JVPRD9352 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9722);
        /*"  02  JVPRD9353                    PIC S9(004) COMP-5 VALUE 9721*/
        public IntBasis JVPRD9353 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9721);
        /*"  02  JVPRD9356A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS 0002 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9356A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 0002);
        /*"  02  JVPRD9356                    PIC S9(004) COMP-5 VALUE 9735*/
        public IntBasis JVPRD9356 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9735);
        /*"  02  JVPRD9357                    PIC S9(004) COMP-5 VALUE 9736*/
        public IntBasis JVPRD9357 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9736);
        /*"  02  JVPRD9358                    PIC S9(004) COMP-5 VALUE 9737*/
        public IntBasis JVPRD9358 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9737);
        /*"  02  JVPRD9359                    PIC S9(004) COMP-5 VALUE 9745*/
        public IntBasis JVPRD9359 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9745);
        /*"  02  JVPRD9360                    PIC S9(004) COMP-5 VALUE 9746*/
        public IntBasis JVPRD9360 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9746);
        /*"  02  JVPRD9361                    PIC S9(004) COMP-5 VALUE 9747*/
        public IntBasis JVPRD9361 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9747);
        /*"  02  JVPRD9801A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS  439 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9801A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 439);
        /*"  02  JVPRD9801                    PIC S9(004) COMP-5 VALUE 9821*/
        public IntBasis JVPRD9801 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9821);
        /*"  02  JVPRD9802                    PIC S9(004) COMP-5 VALUE 9811*/
        public IntBasis JVPRD9802 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 9811);
        /*"  02  JVPRD9999A                   PIC S9(004) COMP-5 VALUE 0                                               OCCURS  197 TIMES*/
        public ListBasis<IntBasis, Int64> JVPRD9999A { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 197);
        /*"01    FILLER             REDEFINES JV-PRODUTOS*/
    }
}