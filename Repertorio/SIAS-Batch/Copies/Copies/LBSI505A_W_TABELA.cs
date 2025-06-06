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
    public class LBSI505A_W_TABELA : VarBasis
    {
        /*"    05  FILLER PIC X(16) VALUE '1116420011131642'*/
        public StringBasis FILLER { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"1116420011131642");
        /*"    05  FILLER PIC X(16) VALUE '1426000002751426'*/
        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"1426000002751426");
        /*"    05  FILLER PIC X(16) VALUE '5001200403551241'*/
        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5001200403551241");
        /*"    05  FILLER PIC X(16) VALUE '5001200407141241'*/
        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5001200407141241");
        /*"    05  FILLER PIC X(16) VALUE '5007800007110787'*/
        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5007800007110787");
        /*"    05  FILLER PIC X(16) VALUE '5016800010000167'*/
        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010000167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010040167'*/
        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010040167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010140167'*/
        public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010140167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010200167'*/
        public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010200167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010210167'*/
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010210167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010340167'*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010340167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010350167'*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010350167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010410167'*/
        public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010410167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010540167'*/
        public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010540167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010550167'*/
        public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010550167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010640167'*/
        public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010640167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010710167'*/
        public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010710167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010850167'*/
        public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010850167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010900167'*/
        public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010900167");
        /*"    05  FILLER PIC X(16) VALUE '5016800010930167'*/
        public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800010930167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011040167'*/
        public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011040167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011230167'*/
        public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011230167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011310167'*/
        public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011310167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011380167'*/
        public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011380167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011450167'*/
        public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011450167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011470167'*/
        public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011470167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011490167'*/
        public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011490167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011520167'*/
        public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011520167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011560167'*/
        public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011560167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011610167'*/
        public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011610167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011680167'*/
        public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011680167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011700167'*/
        public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011700167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011720167'*/
        public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011720167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011750167'*/
        public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011750167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011770167'*/
        public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011770167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011840167'*/
        public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011840167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011850167'*/
        public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011850167");
        /*"    05  FILLER PIC X(16) VALUE '5016800011860167'*/
        public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800011860167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012030167'*/
        public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012030167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012180167'*/
        public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012180167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012230167'*/
        public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012230167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012240167'*/
        public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012240167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012280167'*/
        public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012280167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012310167'*/
        public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012310167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012330167'*/
        public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012330167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012400167'*/
        public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012400167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012530167'*/
        public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012530167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012630167'*/
        public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012630167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012660167'*/
        public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012660167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012670167'*/
        public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012670167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012680167'*/
        public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012680167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012740167'*/
        public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012740167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012780167'*/
        public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012780167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012810167'*/
        public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012810167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012840167'*/
        public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012840167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012860167'*/
        public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012860167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012910167'*/
        public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012910167");
        /*"    05  FILLER PIC X(16) VALUE '5016800012920167'*/
        public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800012920167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013080167'*/
        public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013080167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013090167'*/
        public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013090167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013130167'*/
        public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013130167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013180167'*/
        public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013180167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013290167'*/
        public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013290167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013300167'*/
        public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013300167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013320167'*/
        public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013320167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013330167'*/
        public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013330167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013340167'*/
        public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013340167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013390167'*/
        public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013390167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013400167'*/
        public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013400167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013430167'*/
        public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013430167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013510167'*/
        public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013510167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013720167'*/
        public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013720167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013760167'*/
        public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013760167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013840167'*/
        public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013840167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013850167'*/
        public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013850167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013880167'*/
        public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013880167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013890167'*/
        public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013890167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013900167'*/
        public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013900167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013910167'*/
        public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013910167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013940167'*/
        public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013940167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013950167'*/
        public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013950167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013960167'*/
        public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013960167");
        /*"    05  FILLER PIC X(16) VALUE '5016800013980167'*/
        public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800013980167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014030167'*/
        public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014030167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014050167'*/
        public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014050167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014100167'*/
        public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014100167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014130167'*/
        public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014130167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014210167'*/
        public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014210167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014220167'*/
        public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014220167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014230167'*/
        public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014230167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014260167'*/
        public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014260167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014340167'*/
        public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014340167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014370167'*/
        public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014370167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014390167'*/
        public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014390167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014530167'*/
        public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014530167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014590167'*/
        public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014590167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014610167'*/
        public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014610167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014660167'*/
        public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014660167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014800167'*/
        public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014800167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014820167'*/
        public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014820167");
        /*"    05  FILLER PIC X(16) VALUE '5016800014830167'*/
        public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800014830167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015010167'*/
        public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015010167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015030167'*/
        public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015030167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015080167'*/
        public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015080167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015190167'*/
        public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015190167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015210167'*/
        public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015210167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015460167'*/
        public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015460167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015550167'*/
        public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015550167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015560167'*/
        public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015560167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015600167'*/
        public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015600167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015660167'*/
        public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015660167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015680167'*/
        public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015680167");
        /*"    05  FILLER PIC X(16) VALUE '5016800015870167'*/
        public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5016800015870167");
        /*"    05  FILLER PIC X(16) VALUE '5017470000040175'*/
        public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5017470000040175");
        /*"    05  FILLER PIC X(16) VALUE '5018500000221850'*/
        public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5018500000221850");
        /*"    05  FILLER PIC X(16) VALUE '5019240000681924'*/
        public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019240000681924");
        /*"    05  FILLER PIC X(16) VALUE '5019470000171247'*/
        public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470000171247");
        /*"    05  FILLER PIC X(16) VALUE '5019470001034143'*/
        public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470001034143");
        /*"    05  FILLER PIC X(16) VALUE '5019470001054143'*/
        public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470001054143");
        /*"    05  FILLER PIC X(16) VALUE '5019470001064143'*/
        public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470001064143");
        /*"    05  FILLER PIC X(16) VALUE '5019470001074143'*/
        public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470001074143");
        /*"    05  FILLER PIC X(16) VALUE '5019470001084143'*/
        public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470001084143");
        /*"    05  FILLER PIC X(16) VALUE '5019470001154143'*/
        public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019470001154143");
        /*"    05  FILLER PIC X(16) VALUE '5019800000060231'*/
        public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000060231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000080231'*/
        public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000080231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000130231'*/
        public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000130231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000200231'*/
        public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000200231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000210231'*/
        public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000210231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000220231'*/
        public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000220231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000230231'*/
        public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000230231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000260231'*/
        public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000260231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000280231'*/
        public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000280231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000290231'*/
        public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000290231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000300231'*/
        public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000300231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000350231'*/
        public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000350231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000360231'*/
        public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000360231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000380231'*/
        public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000380231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000400231'*/
        public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000400231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000420231'*/
        public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000420231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000450231'*/
        public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000450231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000470231'*/
        public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000470231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000500231'*/
        public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000500231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000510231'*/
        public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000510231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000530231'*/
        public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000530231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000540231'*/
        public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000540231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000580231'*/
        public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000580231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000590231'*/
        public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000590231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000620231'*/
        public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000620231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000650231'*/
        public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000650231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000660231'*/
        public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000660231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000680231'*/
        public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000680231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000690231'*/
        public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000690231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000720231'*/
        public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000720231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000760231'*/
        public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000760231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000780231'*/
        public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000780231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000790231'*/
        public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000790231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000810231'*/
        public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000810231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000850231'*/
        public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000850231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000880231'*/
        public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000880231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000930231'*/
        public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000930231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000940231'*/
        public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000940231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000950231'*/
        public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000950231");
        /*"    05  FILLER PIC X(16) VALUE '5019800000990231'*/
        public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800000990231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001010231'*/
        public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001010231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001090231'*/
        public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001090231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001100231'*/
        public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001100231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001110231'*/
        public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001110231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001120231'*/
        public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001120231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001140231'*/
        public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001140231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001150231'*/
        public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001150231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001170231'*/
        public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001170231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001180231'*/
        public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001180231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001210231'*/
        public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001210231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001220231'*/
        public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001220231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001300231'*/
        public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001300231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001390231'*/
        public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001390231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001420231'*/
        public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001420231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001460231'*/
        public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001460231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001480231'*/
        public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001480231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001510231'*/
        public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001510231");
        /*"    05  FILLER PIC X(16) VALUE '5019800001590231'*/
        public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5019800001590231");
        /*"    05  FILLER PIC X(16) VALUE '5058800000014020'*/
        public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000014020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000034020'*/
        public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000034020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000064020'*/
        public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000064020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000074020'*/
        public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000074020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000084020'*/
        public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000084020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000094020'*/
        public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000094020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000104020'*/
        public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000104020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000114020'*/
        public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000114020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000144020'*/
        public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000144020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000174020'*/
        public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000174020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000194020'*/
        public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000194020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000234020'*/
        public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000234020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000244020'*/
        public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000244020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000334020'*/
        public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000334020");
        /*"    05  FILLER PIC X(16) VALUE '5058800000354020'*/
        public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5058800000354020");
        /*"    05  FILLER PIC X(16) VALUE '5062500000032915'*/
        public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000032915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000102915'*/
        public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000102915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000112915'*/
        public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000112915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000292915'*/
        public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000292915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000302915'*/
        public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000302915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000312915'*/
        public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000312915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000342915'*/
        public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000342915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000362915'*/
        public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000362915");
        /*"    05  FILLER PIC X(16) VALUE '5062500000382915'*/
        public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5062500000382915");
        /*"    05  FILLER PIC X(16) VALUE '5069100050010114'*/
        public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5069100050010114");
        /*"    05  FILLER PIC X(16) VALUE '5104800000744030'*/
        public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5104800000744030");
        /*"    05  FILLER PIC X(16) VALUE '5124800006203384'*/
        public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5124800006203384");
        /*"    05  FILLER PIC X(16) VALUE '5127900000020503'*/
        public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000020503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000050503'*/
        public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000050503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000090503'*/
        public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000090503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000200503'*/
        public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000200503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000280503'*/
        public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000280503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000340503'*/
        public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000340503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000410503'*/
        public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000410503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000430503'*/
        public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000430503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000460503'*/
        public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000460503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000480503'*/
        public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000480503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000510503'*/
        public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000510503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000580503'*/
        public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000580503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000590503'*/
        public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000590503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000640503'*/
        public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000640503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000660503'*/
        public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000660503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000710503'*/
        public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000710503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000720503'*/
        public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000720503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000730503'*/
        public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000730503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000740503'*/
        public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000740503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000750503'*/
        public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000750503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000810503'*/
        public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000810503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000870503'*/
        public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000870503");
        /*"    05  FILLER PIC X(16) VALUE '5127900000950503'*/
        public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900000950503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001010503'*/
        public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001010503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001050503'*/
        public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001050503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001170503'*/
        public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001170503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001280503'*/
        public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001280503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001300503'*/
        public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001300503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001340503'*/
        public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001340503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001360503'*/
        public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001360503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001440503'*/
        public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001440503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001470503'*/
        public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001470503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001540503'*/
        public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001540503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001570503'*/
        public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001570503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001590503'*/
        public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001590503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001640503'*/
        public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001640503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001690503'*/
        public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001690503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001740503'*/
        public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001740503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001770503'*/
        public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001770503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001800503'*/
        public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001800503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001840503'*/
        public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001840503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001910503'*/
        public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001910503");
        /*"    05  FILLER PIC X(16) VALUE '5127900001940503'*/
        public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900001940503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002000503'*/
        public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002000503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002030503'*/
        public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002030503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002110503'*/
        public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002110503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002120503'*/
        public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002120503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002180503'*/
        public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002180503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002320503'*/
        public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002320503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002370503'*/
        public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002370503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002380503'*/
        public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002380503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002390503'*/
        public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002390503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002400503'*/
        public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002400503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002410503'*/
        public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002410503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002420503'*/
        public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002420503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002440503'*/
        public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002440503");
        /*"    05  FILLER PIC X(16) VALUE '5127900002450503'*/
        public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5127900002450503");
        /*"    05  FILLER PIC X(16) VALUE '5129300000061521'*/
        public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000061521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000091521'*/
        public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000091521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000111521'*/
        public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000111521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000151521'*/
        public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000151521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000301521'*/
        public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000301521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000311521'*/
        public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000311521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000371521'*/
        public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000371521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000381521'*/
        public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000381521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000411521'*/
        public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000411521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000461521'*/
        public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000461521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000551521'*/
        public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000551521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000561521'*/
        public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000561521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000571521'*/
        public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000571521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000581521'*/
        public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000581521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000601521'*/
        public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000601521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000611521'*/
        public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000611521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000631521'*/
        public StringBasis FILLER_280 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000631521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000651521'*/
        public StringBasis FILLER_281 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000651521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000701521'*/
        public StringBasis FILLER_282 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000701521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000791521'*/
        public StringBasis FILLER_283 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000791521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000801521'*/
        public StringBasis FILLER_284 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000801521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000811521'*/
        public StringBasis FILLER_285 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000811521");
        /*"    05  FILLER PIC X(16) VALUE '5129300000861521'*/
        public StringBasis FILLER_286 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5129300000861521");
        /*"    05  FILLER PIC X(16) VALUE '5132200000021294'*/
        public StringBasis FILLER_287 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000021294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000101294'*/
        public StringBasis FILLER_288 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000101294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000221294'*/
        public StringBasis FILLER_289 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000221294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000281294'*/
        public StringBasis FILLER_290 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000281294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000311294'*/
        public StringBasis FILLER_291 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000311294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000381294'*/
        public StringBasis FILLER_292 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000381294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000411294'*/
        public StringBasis FILLER_293 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000411294");
        /*"    05  FILLER PIC X(16) VALUE '5132200000441294'*/
        public StringBasis FILLER_294 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132200000441294");
        /*"    05  FILLER PIC X(16) VALUE '5132600000014020'*/
        public StringBasis FILLER_295 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000014020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000034020'*/
        public StringBasis FILLER_296 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000034020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000084020'*/
        public StringBasis FILLER_297 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000084020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000094020'*/
        public StringBasis FILLER_298 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000094020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000174020'*/
        public StringBasis FILLER_299 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000174020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000184020'*/
        public StringBasis FILLER_300 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000184020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000214020'*/
        public StringBasis FILLER_301 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000214020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000254020'*/
        public StringBasis FILLER_302 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000254020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000274020'*/
        public StringBasis FILLER_303 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000274020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000304020'*/
        public StringBasis FILLER_304 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000304020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000314020'*/
        public StringBasis FILLER_305 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000314020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000354020'*/
        public StringBasis FILLER_306 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000354020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000394020'*/
        public StringBasis FILLER_307 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000394020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000404020'*/
        public StringBasis FILLER_308 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000404020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000414020'*/
        public StringBasis FILLER_309 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000414020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000424020'*/
        public StringBasis FILLER_310 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000424020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000584020'*/
        public StringBasis FILLER_311 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000584020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000674020'*/
        public StringBasis FILLER_312 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000674020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000704020'*/
        public StringBasis FILLER_313 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000704020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000714020'*/
        public StringBasis FILLER_314 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000714020");
        /*"    05  FILLER PIC X(16) VALUE '5132600000744020'*/
        public StringBasis FILLER_315 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5132600000744020");
        /*"    05  FILLER PIC X(16) VALUE '5134400000064043'*/
        public StringBasis FILLER_316 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5134400000064043");
        /*"    05  FILLER PIC X(16) VALUE '5144500003150956'*/
        public StringBasis FILLER_317 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5144500003150956");
        /*"    05  FILLER PIC X(16) VALUE '5144500003200956'*/
        public StringBasis FILLER_318 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5144500003200956");
        /*"    05  FILLER PIC X(16) VALUE '5147000000402715'*/
        public StringBasis FILLER_319 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5147000000402715");
        /*"    05  FILLER PIC X(16) VALUE '5147000000532715'*/
        public StringBasis FILLER_320 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5147000000532715");
        /*"    05  FILLER PIC X(16) VALUE '5147000000932715'*/
        public StringBasis FILLER_321 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5147000000932715");
        /*"    05  FILLER PIC X(16) VALUE '5150550000961502'*/
        public StringBasis FILLER_322 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150550000961502");
        /*"    05  FILLER PIC X(16) VALUE '5150620000870216'*/
        public StringBasis FILLER_323 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620000870216");
        /*"    05  FILLER PIC X(16) VALUE '5150620001340216'*/
        public StringBasis FILLER_324 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620001340216");
        /*"    05  FILLER PIC X(16) VALUE '5150620001350216'*/
        public StringBasis FILLER_325 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620001350216");
        /*"    05  FILLER PIC X(16) VALUE '5150620001480216'*/
        public StringBasis FILLER_326 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620001480216");
        /*"    05  FILLER PIC X(16) VALUE '5150620001750216'*/
        public StringBasis FILLER_327 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620001750216");
        /*"    05  FILLER PIC X(16) VALUE '5150620001970216'*/
        public StringBasis FILLER_328 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620001970216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002040216'*/
        public StringBasis FILLER_329 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002040216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002070216'*/
        public StringBasis FILLER_330 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002070216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002090216'*/
        public StringBasis FILLER_331 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002090216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002150216'*/
        public StringBasis FILLER_332 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002150216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002310216'*/
        public StringBasis FILLER_333 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002310216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002320216'*/
        public StringBasis FILLER_334 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002320216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002340216'*/
        public StringBasis FILLER_335 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002340216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002560216'*/
        public StringBasis FILLER_336 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002560216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002640216'*/
        public StringBasis FILLER_337 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002640216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002650216'*/
        public StringBasis FILLER_338 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002650216");
        /*"    05  FILLER PIC X(16) VALUE '5150620002830216'*/
        public StringBasis FILLER_339 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620002830216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003320216'*/
        public StringBasis FILLER_340 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003320216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003440216'*/
        public StringBasis FILLER_341 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003440216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003450216'*/
        public StringBasis FILLER_342 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003450216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003470216'*/
        public StringBasis FILLER_343 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003470216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003500216'*/
        public StringBasis FILLER_344 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003500216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003530216'*/
        public StringBasis FILLER_345 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003530216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003600216'*/
        public StringBasis FILLER_346 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003600216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003790216'*/
        public StringBasis FILLER_347 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003790216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003920216'*/
        public StringBasis FILLER_348 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003920216");
        /*"    05  FILLER PIC X(16) VALUE '5150620003950216'*/
        public StringBasis FILLER_349 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620003950216");
        /*"    05  FILLER PIC X(16) VALUE '5150620004260216'*/
        public StringBasis FILLER_350 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620004260216");
        /*"    05  FILLER PIC X(16) VALUE '5150620004330216'*/
        public StringBasis FILLER_351 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620004330216");
        /*"    05  FILLER PIC X(16) VALUE '5150620004380216'*/
        public StringBasis FILLER_352 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620004380216");
        /*"    05  FILLER PIC X(16) VALUE '5150620004410216'*/
        public StringBasis FILLER_353 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620004410216");
        /*"    05  FILLER PIC X(16) VALUE '5150620004470216'*/
        public StringBasis FILLER_354 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620004470216");
        /*"    05  FILLER PIC X(16) VALUE '5150620005510216'*/
        public StringBasis FILLER_355 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620005510216");
        /*"    05  FILLER PIC X(16) VALUE '5150620005750216'*/
        public StringBasis FILLER_356 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5150620005750216");
        /*"    05  FILLER PIC X(16) VALUE '5162600500831241'*/
        public StringBasis FILLER_357 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162600500831241");
        /*"    05  FILLER PIC X(16) VALUE '5162900000131284'*/
        public StringBasis FILLER_358 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162900000131284");
        /*"    05  FILLER PIC X(16) VALUE '5162900000231284'*/
        public StringBasis FILLER_359 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162900000231284");
        /*"    05  FILLER PIC X(16) VALUE '5162900000261284'*/
        public StringBasis FILLER_360 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162900000261284");
        /*"    05  FILLER PIC X(16) VALUE '5162900000431284'*/
        public StringBasis FILLER_361 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162900000431284");
        /*"    05  FILLER PIC X(16) VALUE '5162900000461284'*/
        public StringBasis FILLER_362 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162900000461284");
        /*"    05  FILLER PIC X(16) VALUE '5162900000471284'*/
        public StringBasis FILLER_363 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5162900000471284");
        /*"    05  FILLER PIC X(16) VALUE '5196100000031559'*/
        public StringBasis FILLER_364 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000031559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000071559'*/
        public StringBasis FILLER_365 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000071559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000101559'*/
        public StringBasis FILLER_366 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000101559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000131559'*/
        public StringBasis FILLER_367 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000131559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000141559'*/
        public StringBasis FILLER_368 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000141559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000151559'*/
        public StringBasis FILLER_369 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000151559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000211559'*/
        public StringBasis FILLER_370 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000211559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000231559'*/
        public StringBasis FILLER_371 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000231559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000291559'*/
        public StringBasis FILLER_372 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000291559");
        /*"    05  FILLER PIC X(16) VALUE '5196100000431559'*/
        public StringBasis FILLER_373 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5196100000431559");
        /*"    05  FILLER PIC X(16) VALUE '5204000000381826'*/
        public StringBasis FILLER_374 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000000381826");
        /*"    05  FILLER PIC X(16) VALUE '5204000000791826'*/
        public StringBasis FILLER_375 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000000791826");
        /*"    05  FILLER PIC X(16) VALUE '5204000000961826'*/
        public StringBasis FILLER_376 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000000961826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001031826'*/
        public StringBasis FILLER_377 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001031826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001151826'*/
        public StringBasis FILLER_378 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001151826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001241826'*/
        public StringBasis FILLER_379 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001241826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001321826'*/
        public StringBasis FILLER_380 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001321826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001331826'*/
        public StringBasis FILLER_381 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001331826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001471826'*/
        public StringBasis FILLER_382 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001471826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001611826'*/
        public StringBasis FILLER_383 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001611826");
        /*"    05  FILLER PIC X(16) VALUE '5204000001871826'*/
        public StringBasis FILLER_384 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000001871826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002041826'*/
        public StringBasis FILLER_385 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002041826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002091826'*/
        public StringBasis FILLER_386 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002091826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002101826'*/
        public StringBasis FILLER_387 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002101826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002241826'*/
        public StringBasis FILLER_388 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002241826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002471826'*/
        public StringBasis FILLER_389 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002471826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002551826'*/
        public StringBasis FILLER_390 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002551826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002581826'*/
        public StringBasis FILLER_391 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002581826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002591826'*/
        public StringBasis FILLER_392 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002591826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002631826'*/
        public StringBasis FILLER_393 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002631826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002681826'*/
        public StringBasis FILLER_394 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002681826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002791826'*/
        public StringBasis FILLER_395 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002791826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002891826'*/
        public StringBasis FILLER_396 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002891826");
        /*"    05  FILLER PIC X(16) VALUE '5204000002901826'*/
        public StringBasis FILLER_397 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000002901826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003011826'*/
        public StringBasis FILLER_398 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003011826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003061826'*/
        public StringBasis FILLER_399 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003061826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003081826'*/
        public StringBasis FILLER_400 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003081826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003091826'*/
        public StringBasis FILLER_401 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003091826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003101826'*/
        public StringBasis FILLER_402 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003101826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003351826'*/
        public StringBasis FILLER_403 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003351826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003381826'*/
        public StringBasis FILLER_404 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003381826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003441826'*/
        public StringBasis FILLER_405 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003441826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003531826'*/
        public StringBasis FILLER_406 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003531826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003551826'*/
        public StringBasis FILLER_407 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003551826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003641826'*/
        public StringBasis FILLER_408 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003641826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003671826'*/
        public StringBasis FILLER_409 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003671826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003681826'*/
        public StringBasis FILLER_410 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003681826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003791826'*/
        public StringBasis FILLER_411 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003791826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003871826'*/
        public StringBasis FILLER_412 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003871826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003901826'*/
        public StringBasis FILLER_413 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003901826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003921826'*/
        public StringBasis FILLER_414 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003921826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003961826'*/
        public StringBasis FILLER_415 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003961826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003971826'*/
        public StringBasis FILLER_416 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003971826");
        /*"    05  FILLER PIC X(16) VALUE '5204000003981826'*/
        public StringBasis FILLER_417 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000003981826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004011826'*/
        public StringBasis FILLER_418 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004011826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004051826'*/
        public StringBasis FILLER_419 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004051826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004141826'*/
        public StringBasis FILLER_420 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004141826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004151826'*/
        public StringBasis FILLER_421 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004151826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004181826'*/
        public StringBasis FILLER_422 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004181826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004201826'*/
        public StringBasis FILLER_423 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004201826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004211826'*/
        public StringBasis FILLER_424 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004211826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004221826'*/
        public StringBasis FILLER_425 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004221826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004231826'*/
        public StringBasis FILLER_426 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004231826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004331826'*/
        public StringBasis FILLER_427 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004331826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004461826'*/
        public StringBasis FILLER_428 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004461826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004481826'*/
        public StringBasis FILLER_429 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004481826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004711826'*/
        public StringBasis FILLER_430 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004711826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004721826'*/
        public StringBasis FILLER_431 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004721826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004731826'*/
        public StringBasis FILLER_432 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004731826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004861826'*/
        public StringBasis FILLER_433 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004861826");
        /*"    05  FILLER PIC X(16) VALUE '5204000004891826'*/
        public StringBasis FILLER_434 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000004891826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005061826'*/
        public StringBasis FILLER_435 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005061826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005251826'*/
        public StringBasis FILLER_436 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005251826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005471826'*/
        public StringBasis FILLER_437 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005471826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005661826'*/
        public StringBasis FILLER_438 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005661826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005681826'*/
        public StringBasis FILLER_439 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005681826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005861826'*/
        public StringBasis FILLER_440 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005861826");
        /*"    05  FILLER PIC X(16) VALUE '5204000005941826'*/
        public StringBasis FILLER_441 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000005941826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006041826'*/
        public StringBasis FILLER_442 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006041826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006071826'*/
        public StringBasis FILLER_443 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006071826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006141826'*/
        public StringBasis FILLER_444 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006141826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006151826'*/
        public StringBasis FILLER_445 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006151826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006191826'*/
        public StringBasis FILLER_446 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006191826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006221826'*/
        public StringBasis FILLER_447 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006221826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006251826'*/
        public StringBasis FILLER_448 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006251826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006271826'*/
        public StringBasis FILLER_449 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006271826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006281826'*/
        public StringBasis FILLER_450 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006281826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006311826'*/
        public StringBasis FILLER_451 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006311826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006331826'*/
        public StringBasis FILLER_452 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006331826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006421826'*/
        public StringBasis FILLER_453 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006421826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006431826'*/
        public StringBasis FILLER_454 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006431826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006461826'*/
        public StringBasis FILLER_455 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006461826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006531826'*/
        public StringBasis FILLER_456 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006531826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006541826'*/
        public StringBasis FILLER_457 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006541826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006691826'*/
        public StringBasis FILLER_458 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006691826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006711826'*/
        public StringBasis FILLER_459 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006711826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006761826'*/
        public StringBasis FILLER_460 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006761826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006771826'*/
        public StringBasis FILLER_461 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006771826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006781826'*/
        public StringBasis FILLER_462 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006781826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006861826'*/
        public StringBasis FILLER_463 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006861826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006921826'*/
        public StringBasis FILLER_464 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006921826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006951826'*/
        public StringBasis FILLER_465 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006951826");
        /*"    05  FILLER PIC X(16) VALUE '5204000006981826'*/
        public StringBasis FILLER_466 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000006981826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007001826'*/
        public StringBasis FILLER_467 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007001826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007021826'*/
        public StringBasis FILLER_468 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007021826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007041826'*/
        public StringBasis FILLER_469 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007041826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007061826'*/
        public StringBasis FILLER_470 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007061826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007081826'*/
        public StringBasis FILLER_471 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007081826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007101826'*/
        public StringBasis FILLER_472 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007101826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007191826'*/
        public StringBasis FILLER_473 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007191826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007211826'*/
        public StringBasis FILLER_474 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007211826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007231826'*/
        public StringBasis FILLER_475 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007231826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007241826'*/
        public StringBasis FILLER_476 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007241826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007251826'*/
        public StringBasis FILLER_477 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007251826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007281826'*/
        public StringBasis FILLER_478 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007281826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007291826'*/
        public StringBasis FILLER_479 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007291826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007311826'*/
        public StringBasis FILLER_480 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007311826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007331826'*/
        public StringBasis FILLER_481 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007331826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007341826'*/
        public StringBasis FILLER_482 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007341826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007351826'*/
        public StringBasis FILLER_483 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007351826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007391826'*/
        public StringBasis FILLER_484 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007391826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007401826'*/
        public StringBasis FILLER_485 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007401826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007411826'*/
        public StringBasis FILLER_486 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007411826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007441826'*/
        public StringBasis FILLER_487 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007441826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007461826'*/
        public StringBasis FILLER_488 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007461826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007471826'*/
        public StringBasis FILLER_489 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007471826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007491826'*/
        public StringBasis FILLER_490 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007491826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007511826'*/
        public StringBasis FILLER_491 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007511826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007531826'*/
        public StringBasis FILLER_492 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007531826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007541826'*/
        public StringBasis FILLER_493 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007541826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007551826'*/
        public StringBasis FILLER_494 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007551826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007561826'*/
        public StringBasis FILLER_495 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007561826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007611826'*/
        public StringBasis FILLER_496 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007611826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007631826'*/
        public StringBasis FILLER_497 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007631826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007671826'*/
        public StringBasis FILLER_498 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007671826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007681826'*/
        public StringBasis FILLER_499 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007681826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007691826'*/
        public StringBasis FILLER_500 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007691826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007701826'*/
        public StringBasis FILLER_501 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007701826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007721826'*/
        public StringBasis FILLER_502 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007721826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007731826'*/
        public StringBasis FILLER_503 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007731826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007751826'*/
        public StringBasis FILLER_504 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007751826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007771826'*/
        public StringBasis FILLER_505 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007771826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007781826'*/
        public StringBasis FILLER_506 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007781826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007801826'*/
        public StringBasis FILLER_507 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007801826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007821826'*/
        public StringBasis FILLER_508 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007821826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007851826'*/
        public StringBasis FILLER_509 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007851826");
        /*"    05  FILLER PIC X(16) VALUE '5204000007861826'*/
        public StringBasis FILLER_510 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000007861826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008031826'*/
        public StringBasis FILLER_511 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008031826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008041826'*/
        public StringBasis FILLER_512 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008041826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008051826'*/
        public StringBasis FILLER_513 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008051826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008061826'*/
        public StringBasis FILLER_514 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008061826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008071826'*/
        public StringBasis FILLER_515 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008071826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008091826'*/
        public StringBasis FILLER_516 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008091826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008111826'*/
        public StringBasis FILLER_517 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008111826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008121826'*/
        public StringBasis FILLER_518 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008121826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008131826'*/
        public StringBasis FILLER_519 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008131826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008141826'*/
        public StringBasis FILLER_520 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008141826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008151826'*/
        public StringBasis FILLER_521 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008151826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008161826'*/
        public StringBasis FILLER_522 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008161826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008171826'*/
        public StringBasis FILLER_523 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008171826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008411826'*/
        public StringBasis FILLER_524 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008411826");
        /*"    05  FILLER PIC X(16) VALUE '5204000008421826'*/
        public StringBasis FILLER_525 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5204000008421826");
        /*"    05  FILLER PIC X(16) VALUE '5215660434570278'*/
        public StringBasis FILLER_526 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660434570278");
        /*"    05  FILLER PIC X(16) VALUE '5215660434680278'*/
        public StringBasis FILLER_527 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660434680278");
        /*"    05  FILLER PIC X(16) VALUE '5215660434840278'*/
        public StringBasis FILLER_528 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660434840278");
        /*"    05  FILLER PIC X(16) VALUE '5215660434890278'*/
        public StringBasis FILLER_529 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660434890278");
        /*"    05  FILLER PIC X(16) VALUE '5215660435140278'*/
        public StringBasis FILLER_530 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660435140278");
        /*"    05  FILLER PIC X(16) VALUE '5215660435320278'*/
        public StringBasis FILLER_531 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660435320278");
        /*"    05  FILLER PIC X(16) VALUE '5215660435450278'*/
        public StringBasis FILLER_532 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5215660435450278");
        /*"    05  FILLER PIC X(16) VALUE '5232800000072381'*/
        public StringBasis FILLER_533 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5232800000072381");
        /*"    05  FILLER PIC X(16) VALUE '5233404000110113'*/
        public StringBasis FILLER_534 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5233404000110113");
        /*"    05  FILLER PIC X(16) VALUE '5233404000300113'*/
        public StringBasis FILLER_535 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5233404000300113");
        /*"    05  FILLER PIC X(16) VALUE '5243300000161011'*/
        public StringBasis FILLER_536 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5243300000161011");
        /*"    05  FILLER PIC X(16) VALUE '5244400031510996'*/
        public StringBasis FILLER_537 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031510996");
        /*"    05  FILLER PIC X(16) VALUE '5244400031590996'*/
        public StringBasis FILLER_538 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031590996");
        /*"    05  FILLER PIC X(16) VALUE '5244400031650996'*/
        public StringBasis FILLER_539 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031650996");
        /*"    05  FILLER PIC X(16) VALUE '5244400031710996'*/
        public StringBasis FILLER_540 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031710996");
        /*"    05  FILLER PIC X(16) VALUE '5244400031790996'*/
        public StringBasis FILLER_541 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031790996");
        /*"    05  FILLER PIC X(16) VALUE '5244400031860996'*/
        public StringBasis FILLER_542 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031860996");
        /*"    05  FILLER PIC X(16) VALUE '5244400031920996'*/
        public StringBasis FILLER_543 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400031920996");
        /*"    05  FILLER PIC X(16) VALUE '5244400032100996'*/
        public StringBasis FILLER_544 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400032100996");
        /*"    05  FILLER PIC X(16) VALUE '5244400032310996'*/
        public StringBasis FILLER_545 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5244400032310996");
        /*"    05  FILLER PIC X(16) VALUE '5271300000010389'*/
        public StringBasis FILLER_546 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5271300000010389");
        /*"    05  FILLER PIC X(16) VALUE '5272750000060116'*/
        public StringBasis FILLER_547 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5272750000060116");
        /*"    05  FILLER PIC X(16) VALUE '5272750000100116'*/
        public StringBasis FILLER_548 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5272750000100116");
        /*"    05  FILLER PIC X(16) VALUE '5275900000042951'*/
        public StringBasis FILLER_549 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000042951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000052951'*/
        public StringBasis FILLER_550 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000052951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000132951'*/
        public StringBasis FILLER_551 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000132951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000152951'*/
        public StringBasis FILLER_552 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000152951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000162951'*/
        public StringBasis FILLER_553 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000162951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000182951'*/
        public StringBasis FILLER_554 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000182951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000272951'*/
        public StringBasis FILLER_555 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000272951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000342951'*/
        public StringBasis FILLER_556 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000342951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000372951'*/
        public StringBasis FILLER_557 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000372951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000452951'*/
        public StringBasis FILLER_558 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000452951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000462951'*/
        public StringBasis FILLER_559 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000462951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000492951'*/
        public StringBasis FILLER_560 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000492951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000522951'*/
        public StringBasis FILLER_561 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000522951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000702951'*/
        public StringBasis FILLER_562 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000702951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000732951'*/
        public StringBasis FILLER_563 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000732951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000772951'*/
        public StringBasis FILLER_564 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000772951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000802951'*/
        public StringBasis FILLER_565 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000802951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000812951'*/
        public StringBasis FILLER_566 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000812951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000882951'*/
        public StringBasis FILLER_567 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000882951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000912951'*/
        public StringBasis FILLER_568 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000912951");
        /*"    05  FILLER PIC X(16) VALUE '5275900000922951'*/
        public StringBasis FILLER_569 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5275900000922951");
        /*"    05  FILLER PIC X(16) VALUE '5276200000040136'*/
        public StringBasis FILLER_570 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5276200000040136");
        /*"    05  FILLER PIC X(16) VALUE '5276200000100136'*/
        public StringBasis FILLER_571 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5276200000100136");
        /*"    05  FILLER PIC X(16) VALUE '5276200000170136'*/
        public StringBasis FILLER_572 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5276200000170136");
        /*"    05  FILLER PIC X(16) VALUE '5276200000190136'*/
        public StringBasis FILLER_573 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5276200000190136");
        /*"    05  FILLER PIC X(16) VALUE '5279800000122256'*/
        public StringBasis FILLER_574 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000122256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000212256'*/
        public StringBasis FILLER_575 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000212256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000262256'*/
        public StringBasis FILLER_576 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000262256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000412256'*/
        public StringBasis FILLER_577 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000412256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000622256'*/
        public StringBasis FILLER_578 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000622256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000662256'*/
        public StringBasis FILLER_579 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000662256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000712256'*/
        public StringBasis FILLER_580 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000712256");
        /*"    05  FILLER PIC X(16) VALUE '5279800000722256'*/
        public StringBasis FILLER_581 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5279800000722256");
        /*"    05  FILLER PIC X(16) VALUE '5281100000060990'*/
        public StringBasis FILLER_582 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000060990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000100990'*/
        public StringBasis FILLER_583 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000100990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000140990'*/
        public StringBasis FILLER_584 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000140990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000160990'*/
        public StringBasis FILLER_585 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000160990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000170990'*/
        public StringBasis FILLER_586 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000170990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000200990'*/
        public StringBasis FILLER_587 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000200990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000210990'*/
        public StringBasis FILLER_588 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000210990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000220990'*/
        public StringBasis FILLER_589 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000220990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000230990'*/
        public StringBasis FILLER_590 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000230990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000250990'*/
        public StringBasis FILLER_591 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000250990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000340990'*/
        public StringBasis FILLER_592 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000340990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000380990'*/
        public StringBasis FILLER_593 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000380990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000430990'*/
        public StringBasis FILLER_594 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000430990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000450990'*/
        public StringBasis FILLER_595 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000450990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000470990'*/
        public StringBasis FILLER_596 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000470990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000500990'*/
        public StringBasis FILLER_597 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000500990");
        /*"    05  FILLER PIC X(16) VALUE '5281100000510990'*/
        public StringBasis FILLER_598 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281100000510990");
        /*"    05  FILLER PIC X(16) VALUE '5281800000010729'*/
        public StringBasis FILLER_599 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5281800000010729");
        /*"    05  FILLER PIC X(16) VALUE '5282100000020935'*/
        public StringBasis FILLER_600 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5282100000020935");
        /*"    05  FILLER PIC X(16) VALUE '5282800000041177'*/
        public StringBasis FILLER_601 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5282800000041177");
        /*"    05  FILLER PIC X(16) VALUE '5282800000061177'*/
        public StringBasis FILLER_602 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5282800000061177");
        /*"    05  FILLER PIC X(16) VALUE '5282800000241177'*/
        public StringBasis FILLER_603 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5282800000241177");
        /*"    05  FILLER PIC X(16) VALUE '5283100000080278'*/
        public StringBasis FILLER_604 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000080278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000120278'*/
        public StringBasis FILLER_605 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000120278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000180278'*/
        public StringBasis FILLER_606 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000180278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000190278'*/
        public StringBasis FILLER_607 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000190278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000250278'*/
        public StringBasis FILLER_608 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000250278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000290278'*/
        public StringBasis FILLER_609 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000290278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000310278'*/
        public StringBasis FILLER_610 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000310278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000350278'*/
        public StringBasis FILLER_611 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000350278");
        /*"    05  FILLER PIC X(16) VALUE '5283100000430278'*/
        public StringBasis FILLER_612 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5283100000430278");
        /*"    05  FILLER PIC X(16) VALUE '5285700000020232'*/
        public StringBasis FILLER_613 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000020232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000100232'*/
        public StringBasis FILLER_614 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000100232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000180232'*/
        public StringBasis FILLER_615 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000180232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000200232'*/
        public StringBasis FILLER_616 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000200232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000230232'*/
        public StringBasis FILLER_617 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000230232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000270232'*/
        public StringBasis FILLER_618 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000270232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000480232'*/
        public StringBasis FILLER_619 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000480232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000540232'*/
        public StringBasis FILLER_620 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000540232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000590232'*/
        public StringBasis FILLER_621 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000590232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000600232'*/
        public StringBasis FILLER_622 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000600232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000630232'*/
        public StringBasis FILLER_623 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000630232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000690232'*/
        public StringBasis FILLER_624 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000690232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000920232'*/
        public StringBasis FILLER_625 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000920232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000930232'*/
        public StringBasis FILLER_626 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000930232");
        /*"    05  FILLER PIC X(16) VALUE '5285700000990232'*/
        public StringBasis FILLER_627 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700000990232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001220232'*/
        public StringBasis FILLER_628 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001220232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001260232'*/
        public StringBasis FILLER_629 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001260232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001300232'*/
        public StringBasis FILLER_630 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001300232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001460232'*/
        public StringBasis FILLER_631 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001460232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001500232'*/
        public StringBasis FILLER_632 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001500232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001610232'*/
        public StringBasis FILLER_633 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001610232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001620232'*/
        public StringBasis FILLER_634 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001620232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001680232'*/
        public StringBasis FILLER_635 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001680232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001690232'*/
        public StringBasis FILLER_636 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001690232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001710232'*/
        public StringBasis FILLER_637 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001710232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001740232'*/
        public StringBasis FILLER_638 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001740232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001750232'*/
        public StringBasis FILLER_639 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001750232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001830232'*/
        public StringBasis FILLER_640 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001830232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001850232'*/
        public StringBasis FILLER_641 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001850232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001890232'*/
        public StringBasis FILLER_642 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001890232");
        /*"    05  FILLER PIC X(16) VALUE '5285700001900232'*/
        public StringBasis FILLER_643 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5285700001900232");
        /*"    05  FILLER PIC X(16) VALUE '5286000000140296'*/
        public StringBasis FILLER_644 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5286000000140296");
        /*"    05  FILLER PIC X(16) VALUE '5286800000020141'*/
        public StringBasis FILLER_645 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5286800000020141");
        /*"    05  FILLER PIC X(16) VALUE '5286800000200141'*/
        public StringBasis FILLER_646 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5286800000200141");
        /*"    05  FILLER PIC X(16) VALUE '5296000000231217'*/
        public StringBasis FILLER_647 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5296000000231217");
        /*"    05  FILLER PIC X(16) VALUE '5299000000482998'*/
        public StringBasis FILLER_648 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5299000000482998");
        /*"    05  FILLER PIC X(16) VALUE '5314500000360683'*/
        public StringBasis FILLER_649 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5314500000360683");
        /*"    05  FILLER PIC X(16) VALUE '5316300000070998'*/
        public StringBasis FILLER_650 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000070998");
        /*"    05  FILLER PIC X(16) VALUE '5316300000110998'*/
        public StringBasis FILLER_651 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000110998");
        /*"    05  FILLER PIC X(16) VALUE '5316300000270998'*/
        public StringBasis FILLER_652 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000270998");
        /*"    05  FILLER PIC X(16) VALUE '5316300000280998'*/
        public StringBasis FILLER_653 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000280998");
        /*"    05  FILLER PIC X(16) VALUE '5316300000300998'*/
        public StringBasis FILLER_654 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000300998");
        /*"    05  FILLER PIC X(16) VALUE '5316300000340998'*/
        public StringBasis FILLER_655 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000340998");
        /*"    05  FILLER PIC X(16) VALUE '5316300000380998'*/
        public StringBasis FILLER_656 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5316300000380998");
        /*"    05  FILLER PIC X(16) VALUE '5320800000233209'*/
        public StringBasis FILLER_657 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5320800000233209");
        /*"    05  FILLER PIC X(16) VALUE '5397200000030320'*/
        public StringBasis FILLER_658 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5397200000030320");
        /*"    05  FILLER PIC X(16) VALUE '5404200000033087'*/
        public StringBasis FILLER_659 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5404200000033087");
        /*"    05  FILLER PIC X(16) VALUE '5410060000100189'*/
        public StringBasis FILLER_660 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5410060000100189");
        /*"    05  FILLER PIC X(16) VALUE '5410060000120189'*/
        public StringBasis FILLER_661 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5410060000120189");
        /*"    05  FILLER PIC X(16) VALUE '5412400000630956'*/
        public StringBasis FILLER_662 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5412400000630956");
        /*"    05  FILLER PIC X(16) VALUE '5417400000040056'*/
        public StringBasis FILLER_663 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000040056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000050056'*/
        public StringBasis FILLER_664 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000050056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000060056'*/
        public StringBasis FILLER_665 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000060056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000070056'*/
        public StringBasis FILLER_666 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000070056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000080056'*/
        public StringBasis FILLER_667 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000080056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000120056'*/
        public StringBasis FILLER_668 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000120056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000140056'*/
        public StringBasis FILLER_669 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000140056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000150056'*/
        public StringBasis FILLER_670 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000150056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000200056'*/
        public StringBasis FILLER_671 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000200056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000220056'*/
        public StringBasis FILLER_672 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000220056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000240056'*/
        public StringBasis FILLER_673 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000240056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000280056'*/
        public StringBasis FILLER_674 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000280056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000290056'*/
        public StringBasis FILLER_675 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000290056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000310056'*/
        public StringBasis FILLER_676 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000310056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000330056'*/
        public StringBasis FILLER_677 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000330056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000360056'*/
        public StringBasis FILLER_678 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000360056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000380056'*/
        public StringBasis FILLER_679 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000380056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000530056'*/
        public StringBasis FILLER_680 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000530056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000560056'*/
        public StringBasis FILLER_681 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000560056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000570056'*/
        public StringBasis FILLER_682 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000570056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000610056'*/
        public StringBasis FILLER_683 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000610056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000650056'*/
        public StringBasis FILLER_684 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000650056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000690056'*/
        public StringBasis FILLER_685 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000690056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000710056'*/
        public StringBasis FILLER_686 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000710056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000730056'*/
        public StringBasis FILLER_687 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000730056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000750056'*/
        public StringBasis FILLER_688 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000750056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000860056'*/
        public StringBasis FILLER_689 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000860056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000900056'*/
        public StringBasis FILLER_690 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000900056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000940056'*/
        public StringBasis FILLER_691 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000940056");
        /*"    05  FILLER PIC X(16) VALUE '5417400000960056'*/
        public StringBasis FILLER_692 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5417400000960056");
        /*"    05  FILLER PIC X(16) VALUE '5286000000060296'*/
        public StringBasis FILLER_693 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"5286000000060296");
        /*"01  FILLER  REDEFINES  W-TABELA*/
    }
}