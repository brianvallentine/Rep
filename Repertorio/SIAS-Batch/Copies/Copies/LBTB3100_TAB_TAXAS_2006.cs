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
    public class LBTB3100_TAB_TAXAS_2006 : VarBasis
    {
        /*"     10 TX001  PIC X(12) VALUE '000331600816'*/
        public StringBasis TX001_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000331600816");
        /*"     10 TX002  PIC X(12) VALUE '000331600816'*/
        public StringBasis TX002_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000331600816");
        /*"     10 TX003  PIC X(12) VALUE '000331600816'*/
        public StringBasis TX003_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000331600816");
        /*"     10 TX004  PIC X(12) VALUE '000331600816'*/
        public StringBasis TX004_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000331600816");
        /*"     10 TX005  PIC X(12) VALUE '000357228255'*/
        public StringBasis TX005_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000357228255");
        /*"     10 TX006  PIC X(12) VALUE '000362586679'*/
        public StringBasis TX006_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000362586679");
        /*"     10 TX007  PIC X(12) VALUE '000368025479'*/
        public StringBasis TX007_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000368025479");
        /*"     10 TX008  PIC X(12) VALUE '000373545861'*/
        public StringBasis TX008_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000373545861");
        /*"     10 TX009  PIC X(12) VALUE '000379149049'*/
        public StringBasis TX009_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000379149049");
        /*"     10 TX010  PIC X(12) VALUE '000384836285'*/
        public StringBasis TX010_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000384836285");
        /*"     10 TX011  PIC X(12) VALUE '000390608829'*/
        public StringBasis TX011_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000390608829");
        /*"     10 TX012  PIC X(12) VALUE '000396467961'*/
        public StringBasis TX012_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000396467961");
        /*"     10 TX001  PIC X(12) VALUE '000570133078'*/
        public StringBasis TX001_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000570133078");
        /*"     10 TX002  PIC X(12) VALUE '000570133078'*/
        public StringBasis TX002_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000570133078");
        /*"     10 TX003  PIC X(12) VALUE '000570133078'*/
        public StringBasis TX003_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000570133078");
        /*"     10 TX004  PIC X(12) VALUE '000570133078'*/
        public StringBasis TX004_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000570133078");
        /*"     10 TX005  PIC X(12) VALUE '000614195245'*/
        public StringBasis TX005_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000614195245");
        /*"     10 TX006  PIC X(12) VALUE '000623408174'*/
        public StringBasis TX006_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000623408174");
        /*"     10 TX007  PIC X(12) VALUE '000632759296'*/
        public StringBasis TX007_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000632759296");
        /*"     10 TX008  PIC X(12) VALUE '000642250686'*/
        public StringBasis TX008_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000642250686");
        /*"     10 TX009  PIC X(12) VALUE '000651884446'*/
        public StringBasis TX009_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000651884446");
        /*"     10 TX010  PIC X(12) VALUE '000661662713'*/
        public StringBasis TX010_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000661662713");
        /*"     10 TX011  PIC X(12) VALUE '000671587653'*/
        public StringBasis TX011_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000671587653");
        /*"     10 TX012  PIC X(12) VALUE '000681661468'*/
        public StringBasis TX012_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000681661468");
        /*"     10 TX001  PIC X(12) VALUE '000831280378'*/
        public StringBasis TX001_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000831280378");
        /*"     10 TX002  PIC X(12) VALUE '000831280378'*/
        public StringBasis TX002_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000831280378");
        /*"     10 TX003  PIC X(12) VALUE '000831280378'*/
        public StringBasis TX003_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000831280378");
        /*"     10 TX004  PIC X(12) VALUE '000831280378'*/
        public StringBasis TX004_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000831280378");
        /*"     10 TX005  PIC X(12) VALUE '000895525054'*/
        public StringBasis TX005_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000895525054");
        /*"     10 TX006  PIC X(12) VALUE '000908957930'*/
        public StringBasis TX006_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000908957930");
        /*"     10 TX007  PIC X(12) VALUE '000922592299'*/
        public StringBasis TX007_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000922592299");
        /*"     10 TX008  PIC X(12) VALUE '000936431183'*/
        public StringBasis TX008_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000936431183");
        /*"     10 TX009  PIC X(12) VALUE '000950477561'*/
        public StringBasis TX009_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000950477561");
        /*"     10 TX010  PIC X(12) VALUE '000964734816'*/
        public StringBasis TX010_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000964734816");
        /*"     10 TX011  PIC X(12) VALUE '000979205838'*/
        public StringBasis TX011_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000979205838");
        /*"     10 TX012  PIC X(12) VALUE '000993893926'*/
        public StringBasis TX012_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000993893926");
        /*"     10 TX001  PIC X(12) VALUE '001172056837'*/
        public StringBasis TX001_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001172056837");
        /*"     10 TX002  PIC X(12) VALUE '001172056837'*/
        public StringBasis TX002_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001172056837");
        /*"     10 TX003  PIC X(12) VALUE '001172056837'*/
        public StringBasis TX003_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001172056837");
        /*"     10 TX004  PIC X(12) VALUE '001172056837'*/
        public StringBasis TX004_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001172056837");
        /*"     10 TX005  PIC X(12) VALUE '001262638082'*/
        public StringBasis TX005_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001262638082");
        /*"     10 TX006  PIC X(12) VALUE '001281577653'*/
        public StringBasis TX006_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001281577653");
        /*"     10 TX007  PIC X(12) VALUE '001300801318'*/
        public StringBasis TX007_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001300801318");
        /*"     10 TX008  PIC X(12) VALUE '001320313338'*/
        public StringBasis TX008_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001320313338");
        /*"     10 TX009  PIC X(12) VALUE '001340118038'*/
        public StringBasis TX009_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001340118038");
        /*"     10 TX010  PIC X(12) VALUE '001360219809'*/
        public StringBasis TX010_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001360219809");
        /*"     10 TX011  PIC X(12) VALUE '001380623106'*/
        public StringBasis TX011_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001380623106");
        /*"     10 TX012  PIC X(12) VALUE '001401332452'*/
        public StringBasis TX012_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001401332452");
        /*"     10 TX001  PIC X(12) VALUE '000206136925'*/
        public StringBasis TX001_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000206136925");
        /*"     10 TX002  PIC X(12) VALUE '000206136925'*/
        public StringBasis TX002_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000206136925");
        /*"     10 TX003  PIC X(12) VALUE '000206136925'*/
        public StringBasis TX003_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000206136925");
        /*"     10 TX004  PIC X(12) VALUE '000206136925'*/
        public StringBasis TX004_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000206136925");
        /*"     10 TX005  PIC X(12) VALUE '000222068012'*/
        public StringBasis TX005_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000222068012");
        /*"     10 TX006  PIC X(12) VALUE '000225399032'*/
        public StringBasis TX006_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000225399032");
        /*"     10 TX007  PIC X(12) VALUE '000228780018'*/
        public StringBasis TX007_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000228780018");
        /*"     10 TX008  PIC X(12) VALUE '000232211718'*/
        public StringBasis TX008_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000232211718");
        /*"     10 TX009  PIC X(12) VALUE '000235694894'*/
        public StringBasis TX009_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000235694894");
        /*"     10 TX010  PIC X(12) VALUE '000239230317'*/
        public StringBasis TX010_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000239230317");
        /*"     10 TX011  PIC X(12) VALUE '000242818772'*/
        public StringBasis TX011_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000242818772");
        /*"     10 TX012  PIC X(12) VALUE '000246461053'*/
        public StringBasis TX012_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000246461053");
        /*"     10 TX001  PIC X(12) VALUE '001055877792'*/
        public StringBasis TX001_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001055877792");
        /*"     10 TX002  PIC X(12) VALUE '001055877792'*/
        public StringBasis TX002_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001055877792");
        /*"     10 TX003  PIC X(12) VALUE '001055877792'*/
        public StringBasis TX003_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001055877792");
        /*"     10 TX004  PIC X(12) VALUE '001055877792'*/
        public StringBasis TX004_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001055877792");
        /*"     10 TX005  PIC X(12) VALUE '001137480255'*/
        public StringBasis TX005_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001137480255");
        /*"     10 TX006  PIC X(12) VALUE '001154542459'*/
        public StringBasis TX006_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001154542459");
        /*"     10 TX007  PIC X(12) VALUE '001171860596'*/
        public StringBasis TX007_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001171860596");
        /*"     10 TX008  PIC X(12) VALUE '001189438505'*/
        public StringBasis TX008_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001189438505");
        /*"     10 TX019  PIC X(12) VALUE '001207280083'*/
        public StringBasis TX019_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001207280083");
        /*"     10 TX010  PIC X(12) VALUE '001225389284'*/
        public StringBasis TX010_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001225389284");
        /*"     10 TX011  PIC X(12) VALUE '001243770123'*/
        public StringBasis TX011_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001243770123");
        /*"     10 TX012  PIC X(12) VALUE '001262426675'*/
        public StringBasis TX012_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001262426675");
        /*"     10 TX001  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX001_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX002  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX002_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX003  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX003_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX004  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX004_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX005  PIC X(12) VALUE '000834003000'*/
        public StringBasis TX005_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000834003000");
        /*"     10 TX006  PIC X(12) VALUE '000846513045'*/
        public StringBasis TX006_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000846513045");
        /*"     10 TX007  PIC X(12) VALUE '000859210740'*/
        public StringBasis TX007_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000859210740");
        /*"     10 TX008  PIC X(12) VALUE '000872098902'*/
        public StringBasis TX008_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000872098902");
        /*"     10 TX009  PIC X(12) VALUE '000885180385'*/
        public StringBasis TX009_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000885180385");
        /*"     10 TX010  PIC X(12) VALUE '000898458091'*/
        public StringBasis TX010_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000898458091");
        /*"     10 TX011  PIC X(12) VALUE '000911934962'*/
        public StringBasis TX011_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000911934962");
        /*"     10 TX012  PIC X(12) VALUE '000925613987'*/
        public StringBasis TX012_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000925613987");
        /*"     10 TX001  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX001_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX002  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX002_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX003  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX003_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX004  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX004_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX005  PIC X(12) VALUE '000834003000'*/
        public StringBasis TX005_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000834003000");
        /*"     10 TX006  PIC X(12) VALUE '000846513045'*/
        public StringBasis TX006_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000846513045");
        /*"     10 TX007  PIC X(12) VALUE '000859210740'*/
        public StringBasis TX007_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000859210740");
        /*"     10 TX008  PIC X(12) VALUE '000872098902'*/
        public StringBasis TX008_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000872098902");
        /*"     10 TX009  PIC X(12) VALUE '000885180385'*/
        public StringBasis TX009_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000885180385");
        /*"     10 TX010  PIC X(12) VALUE '000898458091'*/
        public StringBasis TX010_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000898458091");
        /*"     10 TX011  PIC X(12) VALUE '000911934962'*/
        public StringBasis TX011_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000911934962");
        /*"     10 TX012  PIC X(12) VALUE '000925613987'*/
        public StringBasis TX012_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000925613987");
        /*"     10 TX001  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX001_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX002  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX002_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX003  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX003_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX004  PIC X(12) VALUE '000774171896'*/
        public StringBasis TX004_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000774171896");
        /*"     10 TX005  PIC X(12) VALUE '000834003000'*/
        public StringBasis TX005_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000834003000");
        /*"     10 TX006  PIC X(12) VALUE '000846513045'*/
        public StringBasis TX006_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000846513045");
        /*"     10 TX007  PIC X(12) VALUE '000859210740'*/
        public StringBasis TX007_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000859210740");
        /*"     10 TX008  PIC X(12) VALUE '000872098902'*/
        public StringBasis TX008_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000872098902");
        /*"     10 TX009  PIC X(12) VALUE '000885180385'*/
        public StringBasis TX009_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000885180385");
        /*"     10 TX010  PIC X(12) VALUE '000898458091'*/
        public StringBasis TX010_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000898458091");
        /*"     10 TX011  PIC X(12) VALUE '000911934962'*/
        public StringBasis TX011_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000911934962");
        /*"     10 TX012  PIC X(12) VALUE '000925613987'*/
        public StringBasis TX012_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000925613987");
        /*"     10 TX001  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX001_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX002  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX002_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX003  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX003_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX004  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX004_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX005  PIC X(12) VALUE '000397519590'*/
        public StringBasis TX005_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000397519590");
        /*"     10 TX006  PIC X(12) VALUE '000403482384'*/
        public StringBasis TX006_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000403482384");
        /*"     10 TX007  PIC X(12) VALUE '000409534620'*/
        public StringBasis TX007_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000409534620");
        /*"     10 TX008  PIC X(12) VALUE '000415677639'*/
        public StringBasis TX008_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000415677639");
        /*"     10 TX009  PIC X(12) VALUE '000421912804'*/
        public StringBasis TX009_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000421912804");
        /*"     10 TX010  PIC X(12) VALUE '000428241496'*/
        public StringBasis TX010_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000428241496");
        /*"     10 TX011  PIC X(12) VALUE '000434665118'*/
        public StringBasis TX011_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000434665118");
        /*"     10 TX012  PIC X(12) VALUE '000441185095'*/
        public StringBasis TX012_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000441185095");
        /*"     10 TX001  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX001_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX002  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX002_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX003  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX003_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX004  PIC X(12) VALUE '000369001664'*/
        public StringBasis TX004_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000369001664");
        /*"     10 TX005  PIC X(12) VALUE '000397519590'*/
        public StringBasis TX005_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000397519590");
        /*"     10 TX006  PIC X(12) VALUE '000403482384'*/
        public StringBasis TX006_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000403482384");
        /*"     10 TX007  PIC X(12) VALUE '000409534620'*/
        public StringBasis TX007_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000409534620");
        /*"     10 TX008  PIC X(12) VALUE '000415677639'*/
        public StringBasis TX008_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000415677639");
        /*"     10 TX009  PIC X(12) VALUE '000421912804'*/
        public StringBasis TX009_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000421912804");
        /*"     10 TX010  PIC X(12) VALUE '000428241496'*/
        public StringBasis TX010_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000428241496");
        /*"     10 TX011  PIC X(12) VALUE '000434665118'*/
        public StringBasis TX011_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000434665118");
        /*"     10 TX012  PIC X(12) VALUE '000441185095'*/
        public StringBasis TX012_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000441185095");
        /*"     10 TX001  PIC X(12) VALUE '000213060491'*/
        public StringBasis TX001_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000213060491");
        /*"     10 TX002  PIC X(12) VALUE '000213060491'*/
        public StringBasis TX002_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000213060491");
        /*"     10 TX003  PIC X(12) VALUE '000213060491'*/
        public StringBasis TX003_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000213060491");
        /*"     10 TX004  PIC X(12) VALUE '000213060491'*/
        public StringBasis TX004_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000213060491");
        /*"     10 TX005  PIC X(12) VALUE '000229526659'*/
        public StringBasis TX005_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000229526659");
        /*"     10 TX006  PIC X(12) VALUE '000232969559'*/
        public StringBasis TX006_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000232969559");
        /*"     10 TX007  PIC X(12) VALUE '000236464102'*/
        public StringBasis TX007_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000236464102");
        /*"     10 TX008  PIC X(12) VALUE '000240011064'*/
        public StringBasis TX008_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000240011064");
        /*"     10 TX009  PIC X(12) VALUE '000243611230'*/
        public StringBasis TX009_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000243611230");
        /*"     10 TX010  PIC X(12) VALUE '000247265398'*/
        public StringBasis TX010_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000247265398");
        /*"     10 TX011  PIC X(12) VALUE '000250974379'*/
        public StringBasis TX011_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000250974379");
        /*"     10 TX012  PIC X(12) VALUE '000254738995'*/
        public StringBasis TX012_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000254738995");
        /*"     10 TX001  PIC X(12) VALUE '000212616822'*/
        public StringBasis TX001_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000212616822");
        /*"     10 TX002  PIC X(12) VALUE '000212616822'*/
        public StringBasis TX002_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000212616822");
        /*"     10 TX003  PIC X(12) VALUE '000212616822'*/
        public StringBasis TX003_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000212616822");
        /*"     10 TX004  PIC X(12) VALUE '000212616822'*/
        public StringBasis TX004_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000212616822");
        /*"     10 TX005  PIC X(12) VALUE '000229048701'*/
        public StringBasis TX005_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000229048701");
        /*"     10 TX006  PIC X(12) VALUE '000232484432'*/
        public StringBasis TX006_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000232484432");
        /*"     10 TX007  PIC X(12) VALUE '000235971698'*/
        public StringBasis TX007_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000235971698");
        /*"     10 TX008  PIC X(12) VALUE '000239511274'*/
        public StringBasis TX008_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000239511274");
        /*"     10 TX009  PIC X(12) VALUE '000243103943'*/
        public StringBasis TX009_28 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000243103943");
        /*"     10 TX010  PIC X(12) VALUE '000246750502'*/
        public StringBasis TX010_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000246750502");
        /*"     10 TX011  PIC X(12) VALUE '000250451760'*/
        public StringBasis TX011_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000250451760");
        /*"     10 TX012  PIC X(12) VALUE '000254208536'*/
        public StringBasis TX012_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000254208536");
        /*"     10 TX001  PIC X(12) VALUE '000001904000'*/
        public StringBasis TX001_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001904000");
        /*"     10 TX002  PIC X(12) VALUE '000001904000'*/
        public StringBasis TX002_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001904000");
        /*"     10 TX003  PIC X(12) VALUE '000001904000'*/
        public StringBasis TX003_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001904000");
        /*"     10 TX004  PIC X(12) VALUE '000001904000'*/
        public StringBasis TX004_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001904000");
        /*"     10 TX005  PIC X(12) VALUE '000002051149'*/
        public StringBasis TX005_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002051149");
        /*"     10 TX006  PIC X(12) VALUE '000002081916'*/
        public StringBasis TX006_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002081916");
        /*"     10 TX007  PIC X(12) VALUE '000002113145'*/
        public StringBasis TX007_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002113145");
        /*"     10 TX008  PIC X(12) VALUE '000002144842'*/
        public StringBasis TX008_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002144842");
        /*"     10 TX009  PIC X(12) VALUE '000002177015'*/
        public StringBasis TX009_29 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002177015");
        /*"     10 TX010  PIC X(12) VALUE '000002209670'*/
        public StringBasis TX010_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002209670");
        /*"     10 TX011  PIC X(12) VALUE '000002242815'*/
        public StringBasis TX011_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002242815");
        /*"     10 TX012  PIC X(12) VALUE '000002276457'*/
        public StringBasis TX012_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002276457");
        /*"     10 TX001  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX001_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX002  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX002_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX003  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX003_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX004  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX004_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX005  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX005_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX006  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX006_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX007  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX007_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX008  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX008_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX009  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX009_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX010  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX010_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX011  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX011_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX012  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX012_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX001  PIC X(12) VALUE '000006793600'*/
        public StringBasis TX001_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006793600");
        /*"     10 TX002  PIC X(12) VALUE '000006793600'*/
        public StringBasis TX002_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006793600");
        /*"     10 TX003  PIC X(12) VALUE '000006793600'*/
        public StringBasis TX003_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006793600");
        /*"     10 TX004  PIC X(12) VALUE '000006793600'*/
        public StringBasis TX004_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006793600");
        /*"     10 TX005  PIC X(12) VALUE '000007318637'*/
        public StringBasis TX005_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007318637");
        /*"     10 TX006  PIC X(12) VALUE '000007428416'*/
        public StringBasis TX006_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007428416");
        /*"     10 TX007  PIC X(12) VALUE '000007539842'*/
        public StringBasis TX007_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007539842");
        /*"     10 TX008  PIC X(12) VALUE '000007652940'*/
        public StringBasis TX008_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007652940");
        /*"     10 TX009  PIC X(12) VALUE '000007767734'*/
        public StringBasis TX009_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007767734");
        /*"     10 TX010  PIC X(12) VALUE '000007884250'*/
        public StringBasis TX010_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007884250");
        /*"     10 TX011  PIC X(12) VALUE '000008002514'*/
        public StringBasis TX011_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000008002514");
        /*"     10 TX012  PIC X(12) VALUE '000008122552'*/
        public StringBasis TX012_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000008122552");
        /*"     10 TX001  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX001_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX002  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX002_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX003  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX003_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX004  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX004_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX005  PIC X(12) VALUE '000002054021'*/
        public StringBasis TX005_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002054021");
        /*"     10 TX006  PIC X(12) VALUE '000002084831'*/
        public StringBasis TX006_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002084831");
        /*"     10 TX007  PIC X(12) VALUE '000002116104'*/
        public StringBasis TX007_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002116104");
        /*"     10 TX008  PIC X(12) VALUE '000002147845'*/
        public StringBasis TX008_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002147845");
        /*"     10 TX009  PIC X(12) VALUE '000002180063'*/
        public StringBasis TX009_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002180063");
        /*"     10 TX010  PIC X(12) VALUE '000002212764'*/
        public StringBasis TX010_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002212764");
        /*"     10 TX011  PIC X(12) VALUE '000002245955'*/
        public StringBasis TX011_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002245955");
        /*"     10 TX012  PIC X(12) VALUE '000002279645'*/
        public StringBasis TX012_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002279645");
        /*"     10 TX001  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX001_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX002  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX002_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX003  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX003_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX004  PIC X(12) VALUE '000001906666'*/
        public StringBasis TX004_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906666");
        /*"     10 TX005  PIC X(12) VALUE '000002054021'*/
        public StringBasis TX005_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002054021");
        /*"     10 TX006  PIC X(12) VALUE '000002084831'*/
        public StringBasis TX006_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002084831");
        /*"     10 TX007  PIC X(12) VALUE '000002116104'*/
        public StringBasis TX007_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002116104");
        /*"     10 TX008  PIC X(12) VALUE '000002147845'*/
        public StringBasis TX008_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002147845");
        /*"     10 TX009  PIC X(12) VALUE '000002180063'*/
        public StringBasis TX009_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002180063");
        /*"     10 TX010  PIC X(12) VALUE '000002212764'*/
        public StringBasis TX010_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002212764");
        /*"     10 TX011  PIC X(12) VALUE '000002245955'*/
        public StringBasis TX011_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002245955");
        /*"     10 TX012  PIC X(12) VALUE '000002279645'*/
        public StringBasis TX012_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002279645");
        /*"     10 TX001  PIC X(12) VALUE '000001173334'*/
        public StringBasis TX001_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001173334");
        /*"     10 TX002  PIC X(12) VALUE '000001173334'*/
        public StringBasis TX002_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001173334");
        /*"     10 TX003  PIC X(12) VALUE '000001173334'*/
        public StringBasis TX003_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001173334");
        /*"     10 TX004  PIC X(12) VALUE '000001173334'*/
        public StringBasis TX004_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001173334");
        /*"     10 TX005  PIC X(12) VALUE '000001264014'*/
        public StringBasis TX005_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001264014");
        /*"     10 TX006  PIC X(12) VALUE '000001282974'*/
        public StringBasis TX006_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001282974");
        /*"     10 TX007  PIC X(12) VALUE '000001302219'*/
        public StringBasis TX007_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001302219");
        /*"     10 TX008  PIC X(12) VALUE '000001321752'*/
        public StringBasis TX008_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001321752");
        /*"     10 TX009  PIC X(12) VALUE '000001341578'*/
        public StringBasis TX009_34 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001341578");
        /*"     10 TX010  PIC X(12) VALUE '000001361702'*/
        public StringBasis TX010_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001361702");
        /*"     10 TX011  PIC X(12) VALUE '000001382128'*/
        public StringBasis TX011_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001382128");
        /*"     10 TX012  PIC X(12) VALUE '000001402859'*/
        public StringBasis TX012_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001402859");
        /*"01 TAB-TAXAS-2006-R  REDEFINES TAB-TAXAS-2006*/
    }
}