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
    public class LBTB3100_TAB_TAXAS_20042005 : VarBasis
    {
        /*"     10 TX001  PIC X(12) VALUE '000299522151'*/
        public StringBasis TX001 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000299522151");
        /*"     10 TX002  PIC X(12) VALUE '000299522151'*/
        public StringBasis TX002 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000299522151");
        /*"     10 TX003  PIC X(12) VALUE '000299522151'*/
        public StringBasis TX003 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000299522151");
        /*"     10 TX004  PIC X(12) VALUE '000299522151'*/
        public StringBasis TX004 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000299522151");
        /*"     10 TX005  PIC X(12) VALUE '000322670422'*/
        public StringBasis TX005 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000322670422");
        /*"     10 TX006  PIC X(12) VALUE '000327510478'*/
        public StringBasis TX006 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000327510478");
        /*"     10 TX007  PIC X(12) VALUE '000332423136'*/
        public StringBasis TX007 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000332423136");
        /*"     10 TX008  PIC X(12) VALUE '000337409483'*/
        public StringBasis TX008 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000337409483");
        /*"     10 TX009  PIC X(12) VALUE '000342470625'*/
        public StringBasis TX009 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000342470625");
        /*"     10 TX010  PIC X(12) VALUE '000347607684'*/
        public StringBasis TX010 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000347607684");
        /*"     10 TX011  PIC X(12) VALUE '000352821799'*/
        public StringBasis TX011 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000352821799");
        /*"     10 TX012  PIC X(12) VALUE '000358114126'*/
        public StringBasis TX012 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000358114126");
        /*"     10 TX001  PIC X(12) VALUE '000514946429'*/
        public StringBasis TX001_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000514946429");
        /*"     10 TX002  PIC X(12) VALUE '000514946429'*/
        public StringBasis TX002_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000514946429");
        /*"     10 TX003  PIC X(12) VALUE '000514946429'*/
        public StringBasis TX003_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000514946429");
        /*"     10 TX004  PIC X(12) VALUE '000514946429'*/
        public StringBasis TX004_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000514946429");
        /*"     10 TX005  PIC X(12) VALUE '000554743551'*/
        public StringBasis TX005_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000554743551");
        /*"     10 TX006  PIC X(12) VALUE '000563064704'*/
        public StringBasis TX006_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000563064704");
        /*"     10 TX007  PIC X(12) VALUE '000571510675'*/
        public StringBasis TX007_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000571510675");
        /*"     10 TX008  PIC X(12) VALUE '000580083335'*/
        public StringBasis TX008_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000580083335");
        /*"     10 TX009  PIC X(12) VALUE '000588784585'*/
        public StringBasis TX009_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000588784585");
        /*"     10 TX010  PIC X(12) VALUE '000597616354'*/
        public StringBasis TX010_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000597616354");
        /*"     10 TX011  PIC X(12) VALUE '000606580599'*/
        public StringBasis TX011_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000606580599");
        /*"     10 TX012  PIC X(12) VALUE '000615679308'*/
        public StringBasis TX012_0 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000615679308");
        /*"     10 TX001  PIC X(12) VALUE '000876590785'*/
        public StringBasis TX001_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000876590785");
        /*"     10 TX002  PIC X(12) VALUE '000876590785'*/
        public StringBasis TX002_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000876590785");
        /*"     10 TX003  PIC X(12) VALUE '000876590785'*/
        public StringBasis TX003_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000876590785");
        /*"     10 TX004  PIC X(12) VALUE '000876590785'*/
        public StringBasis TX004_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000876590785");
        /*"     10 TX005  PIC X(12) VALUE '000944337231'*/
        public StringBasis TX005_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000944337231");
        /*"     10 TX006  PIC X(12) VALUE '000958502289'*/
        public StringBasis TX006_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000958502289");
        /*"     10 TX007  PIC X(12) VALUE '000972879823'*/
        public StringBasis TX007_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000972879823");
        /*"     10 TX008  PIC X(12) VALUE '000987473021'*/
        public StringBasis TX008_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000987473021");
        /*"     10 TX009  PIC X(12) VALUE '001002285116'*/
        public StringBasis TX009_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001002285116");
        /*"     10 TX010  PIC X(12) VALUE '001017319393'*/
        public StringBasis TX010_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001017319393");
        /*"     10 TX011  PIC X(12) VALUE '001032579184'*/
        public StringBasis TX011_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001032579184");
        /*"     10 TX012  PIC X(12) VALUE '001048067871'*/
        public StringBasis TX012_1 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001048067871");
        /*"     10 TX001  PIC X(12) VALUE '001076466637'*/
        public StringBasis TX001_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001076466637");
        /*"     10 TX002  PIC X(12) VALUE '001076466637'*/
        public StringBasis TX002_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001076466637");
        /*"     10 TX003  PIC X(12) VALUE '001076466637'*/
        public StringBasis TX003_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001076466637");
        /*"     10 TX004  PIC X(12) VALUE '001076466637'*/
        public StringBasis TX004_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001076466637");
        /*"     10 TX005  PIC X(12) VALUE '001159660289'*/
        public StringBasis TX005_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001159660289");
        /*"     10 TX006  PIC X(12) VALUE '001177055193'*/
        public StringBasis TX006_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001177055193");
        /*"     10 TX007  PIC X(12) VALUE '001194711021'*/
        public StringBasis TX007_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001194711021");
        /*"     10 TX008  PIC X(12) VALUE '001212631686'*/
        public StringBasis TX008_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001212631686");
        /*"     10 TX009  PIC X(12) VALUE '001230821162'*/
        public StringBasis TX009_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001230821162");
        /*"     10 TX010  PIC X(12) VALUE '001249283479'*/
        public StringBasis TX010_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001249283479");
        /*"     10 TX011  PIC X(12) VALUE '001268022731'*/
        public StringBasis TX011_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001268022731");
        /*"     10 TX012  PIC X(12) VALUE '001287043072'*/
        public StringBasis TX012_2 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001287043072");
        /*"     10 TX001  PIC X(12) VALUE '000187201345'*/
        public StringBasis TX001_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000187201345");
        /*"     10 TX002  PIC X(12) VALUE '000187201345'*/
        public StringBasis TX002_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000187201345");
        /*"     10 TX003  PIC X(12) VALUE '000187201345'*/
        public StringBasis TX003_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000187201345");
        /*"     10 TX004  PIC X(12) VALUE '000187201345'*/
        public StringBasis TX004_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000187201345");
        /*"     10 TX005  PIC X(12) VALUE '000201669014'*/
        public StringBasis TX005_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000201669014");
        /*"     10 TX006  PIC X(12) VALUE '000204694050'*/
        public StringBasis TX006_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000204694050");
        /*"     10 TX007  PIC X(12) VALUE '000207764460'*/
        public StringBasis TX007_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000207764460");
        /*"     10 TX008  PIC X(12) VALUE '000210880927'*/
        public StringBasis TX008_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000210880927");
        /*"     10 TX009  PIC X(12) VALUE '000214044141'*/
        public StringBasis TX009_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000214044141");
        /*"     10 TX010  PIC X(12) VALUE '000217254803'*/
        public StringBasis TX010_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000217254803");
        /*"     10 TX011  PIC X(12) VALUE '000220513625'*/
        public StringBasis TX011_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000220513625");
        /*"     10 TX012  PIC X(12) VALUE '000223821330'*/
        public StringBasis TX012_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000223821330");
        /*"     10 TX001  PIC X(12) VALUE '000974656423'*/
        public StringBasis TX001_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000974656423");
        /*"     10 TX002  PIC X(12) VALUE '000974656423'*/
        public StringBasis TX002_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000974656423");
        /*"     10 TX003  PIC X(12) VALUE '000974656423'*/
        public StringBasis TX003_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000974656423");
        /*"     10 TX004  PIC X(12) VALUE '000974656423'*/
        public StringBasis TX004_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000974656423");
        /*"     10 TX005  PIC X(12) VALUE '001049981774'*/
        public StringBasis TX005_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001049981774");
        /*"     10 TX006  PIC X(12) VALUE '001065731500'*/
        public StringBasis TX006_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001065731500");
        /*"     10 TX007  PIC X(12) VALUE '001081717473'*/
        public StringBasis TX007_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001081717473");
        /*"     10 TX008  PIC X(12) VALUE '001097943235'*/
        public StringBasis TX008_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001097943235");
        /*"     10 TX019  PIC X(12) VALUE '001114412384'*/
        public StringBasis TX019 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001114412384");
        /*"     10 TX010  PIC X(12) VALUE '001131128569'*/
        public StringBasis TX010_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001131128569");
        /*"     10 TX011  PIC X(12) VALUE '001148095498'*/
        public StringBasis TX011_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001148095498");
        /*"     10 TX012  PIC X(12) VALUE '001165316930'*/
        public StringBasis TX012_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"001165316930");
        /*"     10 TX001  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX001_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX002  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX002_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX003  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX003_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX004  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX004_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX005  PIC X(12) VALUE '000769848923'*/
        public StringBasis TX005_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000769848923");
        /*"     10 TX006  PIC X(12) VALUE '000781396657'*/
        public StringBasis TX006_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000781396657");
        /*"     10 TX007  PIC X(12) VALUE '000793117607'*/
        public StringBasis TX007_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000793117607");
        /*"     10 TX008  PIC X(12) VALUE '000805014371'*/
        public StringBasis TX008_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000805014371");
        /*"     10 TX009  PIC X(12) VALUE '000817089587'*/
        public StringBasis TX009_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000817089587");
        /*"     10 TX010  PIC X(12) VALUE '000829345930'*/
        public StringBasis TX010_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000829345930");
        /*"     10 TX011  PIC X(12) VALUE '000841786119'*/
        public StringBasis TX011_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000841786119");
        /*"     10 TX012  PIC X(12) VALUE '000854412911'*/
        public StringBasis TX012_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000854412911");
        /*"     10 TX001  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX001_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX002  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX002_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX003  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX003_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX004  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX004_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX005  PIC X(12) VALUE '000769848923'*/
        public StringBasis TX005_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000769848923");
        /*"     10 TX006  PIC X(12) VALUE '000781396657'*/
        public StringBasis TX006_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000781396657");
        /*"     10 TX007  PIC X(12) VALUE '000793117607'*/
        public StringBasis TX007_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000793117607");
        /*"     10 TX008  PIC X(12) VALUE '000805014371'*/
        public StringBasis TX008_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000805014371");
        /*"     10 TX009  PIC X(12) VALUE '000817089587'*/
        public StringBasis TX009_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000817089587");
        /*"     10 TX010  PIC X(12) VALUE '000829345930'*/
        public StringBasis TX010_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000829345930");
        /*"     10 TX011  PIC X(12) VALUE '000841786119'*/
        public StringBasis TX011_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000841786119");
        /*"     10 TX012  PIC X(12) VALUE '000854412911'*/
        public StringBasis TX012_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000854412911");
        /*"     10 TX001  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX001_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX002  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX002_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX003  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX003_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX004  PIC X(12) VALUE '000714620212'*/
        public StringBasis TX004_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000714620212");
        /*"     10 TX005  PIC X(12) VALUE '000769848923'*/
        public StringBasis TX005_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000769848923");
        /*"     10 TX006  PIC X(12) VALUE '000781396657'*/
        public StringBasis TX006_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000781396657");
        /*"     10 TX007  PIC X(12) VALUE '000793117607'*/
        public StringBasis TX007_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000793117607");
        /*"     10 TX008  PIC X(12) VALUE '000805014371'*/
        public StringBasis TX008_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000805014371");
        /*"     10 TX009  PIC X(12) VALUE '000817089587'*/
        public StringBasis TX009_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000817089587");
        /*"     10 TX010  PIC X(12) VALUE '000829345930'*/
        public StringBasis TX010_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000829345930");
        /*"     10 TX011  PIC X(12) VALUE '000841786119'*/
        public StringBasis TX011_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000841786119");
        /*"     10 TX012  PIC X(12) VALUE '000854412911'*/
        public StringBasis TX012_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000854412911");
        /*"     10 TX001  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX001_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX002  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX002_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX003  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX003_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX004  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX004_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX005  PIC X(12) VALUE '000366941160'*/
        public StringBasis TX005_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000366941160");
        /*"     10 TX006  PIC X(12) VALUE '000372445278'*/
        public StringBasis TX006_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000372445278");
        /*"     10 TX007  PIC X(12) VALUE '000378031957'*/
        public StringBasis TX007_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000378031957");
        /*"     10 TX008  PIC X(12) VALUE '000383702436'*/
        public StringBasis TX008_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000383702436");
        /*"     10 TX009  PIC X(12) VALUE '000389457973'*/
        public StringBasis TX009_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000389457973");
        /*"     10 TX010  PIC X(12) VALUE '000395299843'*/
        public StringBasis TX010_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000395299843");
        /*"     10 TX011  PIC X(12) VALUE '000401229340'*/
        public StringBasis TX011_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000401229340");
        /*"     10 TX012  PIC X(12) VALUE '000407247780'*/
        public StringBasis TX012_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000407247780");
        /*"     10 TX001  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX001_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX002  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX002_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX003  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX003_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX004  PIC X(12) VALUE '000340616921'*/
        public StringBasis TX004_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000340616921");
        /*"     10 TX005  PIC X(12) VALUE '000366941160'*/
        public StringBasis TX005_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000366941160");
        /*"     10 TX006  PIC X(12) VALUE '000372445278'*/
        public StringBasis TX006_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000372445278");
        /*"     10 TX007  PIC X(12) VALUE '000378031957'*/
        public StringBasis TX007_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000378031957");
        /*"     10 TX008  PIC X(12) VALUE '000383702436'*/
        public StringBasis TX008_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000383702436");
        /*"     10 TX009  PIC X(12) VALUE '000389457973'*/
        public StringBasis TX009_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000389457973");
        /*"     10 TX010  PIC X(12) VALUE '000395299843'*/
        public StringBasis TX010_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000395299843");
        /*"     10 TX011  PIC X(12) VALUE '000401229340'*/
        public StringBasis TX011_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000401229340");
        /*"     10 TX012  PIC X(12) VALUE '000407247780'*/
        public StringBasis TX012_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000407247780");
        /*"     10 TX001  PIC X(12) VALUE '000196671221'*/
        public StringBasis TX001_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196671221");
        /*"     10 TX002  PIC X(12) VALUE '000196671221'*/
        public StringBasis TX002_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196671221");
        /*"     10 TX003  PIC X(12) VALUE '000196671221'*/
        public StringBasis TX003_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196671221");
        /*"     10 TX004  PIC X(12) VALUE '000196671221'*/
        public StringBasis TX004_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196671221");
        /*"     10 TX005  PIC X(12) VALUE '000211870760'*/
        public StringBasis TX005_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000211870760");
        /*"     10 TX006  PIC X(12) VALUE '000215048822'*/
        public StringBasis TX006_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000215048822");
        /*"     10 TX007  PIC X(12) VALUE '000218274554'*/
        public StringBasis TX007_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000218274554");
        /*"     10 TX008  PIC X(12) VALUE '000221548672'*/
        public StringBasis TX008_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000221548672");
        /*"     10 TX009  PIC X(12) VALUE '000224871903'*/
        public StringBasis TX009_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000224871903");
        /*"     10 TX010  PIC X(12) VALUE '000228244981'*/
        public StringBasis TX010_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000228244981");
        /*"     10 TX011  PIC X(12) VALUE '000231668656'*/
        public StringBasis TX011_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000231668656");
        /*"     10 TX012  PIC X(12) VALUE '000235143686'*/
        public StringBasis TX012_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000235143686");
        /*"     10 TX001  PIC X(12) VALUE '000196261682'*/
        public StringBasis TX001_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196261682");
        /*"     10 TX002  PIC X(12) VALUE '000196261682'*/
        public StringBasis TX002_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196261682");
        /*"     10 TX003  PIC X(12) VALUE '000196261682'*/
        public StringBasis TX003_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196261682");
        /*"     10 TX004  PIC X(12) VALUE '000196261682'*/
        public StringBasis TX004_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000196261682");
        /*"     10 TX005  PIC X(12) VALUE '000211429571'*/
        public StringBasis TX005_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000211429571");
        /*"     10 TX006  PIC X(12) VALUE '000214601014'*/
        public StringBasis TX006_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000214601014");
        /*"     10 TX007  PIC X(12) VALUE '000217820029'*/
        public StringBasis TX007_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000217820029");
        /*"     10 TX008  PIC X(12) VALUE '000221087330'*/
        public StringBasis TX008_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000221087330");
        /*"     10 TX009  PIC X(12) VALUE '000224403640'*/
        public StringBasis TX009_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000224403640");
        /*"     10 TX010  PIC X(12) VALUE '000227769694'*/
        public StringBasis TX010_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000227769694");
        /*"     10 TX011  PIC X(12) VALUE '000231186240'*/
        public StringBasis TX011_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000231186240");
        /*"     10 TX012  PIC X(12) VALUE '000234654033'*/
        public StringBasis TX012_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000234654033");
        /*"     10 TX001  PIC X(12) VALUE '000001705075'*/
        public StringBasis TX001_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001705075");
        /*"     10 TX002  PIC X(12) VALUE '000001705075'*/
        public StringBasis TX002_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001705075");
        /*"     10 TX003  PIC X(12) VALUE '000001705075'*/
        public StringBasis TX003_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001705075");
        /*"     10 TX004  PIC X(12) VALUE '000001705075'*/
        public StringBasis TX004_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001705075");
        /*"     10 TX005  PIC X(12) VALUE '000001836850'*/
        public StringBasis TX005_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001836850");
        /*"     10 TX006  PIC X(12) VALUE '000001864403'*/
        public StringBasis TX006_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001864403");
        /*"     10 TX007  PIC X(12) VALUE '000001892369'*/
        public StringBasis TX007_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001892369");
        /*"     10 TX008  PIC X(12) VALUE '000001920754'*/
        public StringBasis TX008_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001920754");
        /*"     10 TX009  PIC X(12) VALUE '000001949566'*/
        public StringBasis TX009_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001949566");
        /*"     10 TX010  PIC X(12) VALUE '000001978809'*/
        public StringBasis TX010_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001978809");
        /*"     10 TX011  PIC X(12) VALUE '000002008491'*/
        public StringBasis TX011_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002008491");
        /*"     10 TX012  PIC X(12) VALUE '000002038619'*/
        public StringBasis TX012_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002038619");
        /*"     10 TX001  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX001_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX002  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX002_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX003  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX003_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX004  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX004_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX005  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX005_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX006  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX006_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX007  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX007_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX008  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX008_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX009  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX009_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX010  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX010_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX011  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX011_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX012  PIC X(12) VALUE '000000000000'*/
        public StringBasis TX012_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000000000000");
        /*"     10 TX001  PIC X(12) VALUE '000006213659'*/
        public StringBasis TX001_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006213659");
        /*"     10 TX002  PIC X(12) VALUE '000006213659'*/
        public StringBasis TX002_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006213659");
        /*"     10 TX003  PIC X(12) VALUE '000006213659'*/
        public StringBasis TX003_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006213659");
        /*"     10 TX004  PIC X(12) VALUE '000006213659'*/
        public StringBasis TX004_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006213659");
        /*"     10 TX005  PIC X(12) VALUE '000006693875'*/
        public StringBasis TX005_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006693875");
        /*"     10 TX006  PIC X(12) VALUE '000006794284'*/
        public StringBasis TX006_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006794284");
        /*"     10 TX007  PIC X(12) VALUE '000006896198'*/
        public StringBasis TX007_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006896198");
        /*"     10 TX008  PIC X(12) VALUE '000006999641'*/
        public StringBasis TX008_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000006999641");
        /*"     10 TX009  PIC X(12) VALUE '000007104635'*/
        public StringBasis TX009_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007104635");
        /*"     10 TX010  PIC X(12) VALUE '000007211205'*/
        public StringBasis TX010_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007211205");
        /*"     10 TX011  PIC X(12) VALUE '000007319373'*/
        public StringBasis TX011_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007319373");
        /*"     10 TX012  PIC X(12) VALUE '000007429164'*/
        public StringBasis TX012_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000007429164");
        /*"     10 TX001  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX001_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX002  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX002_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX003  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX003_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX004  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX004_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX005  PIC X(12) VALUE '000001878679'*/
        public StringBasis TX005_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001878679");
        /*"     10 TX006  PIC X(12) VALUE '000001906859'*/
        public StringBasis TX006_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906859");
        /*"     10 TX007  PIC X(12) VALUE '000001935462'*/
        public StringBasis TX007_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001935462");
        /*"     10 TX008  PIC X(12) VALUE '000001964494'*/
        public StringBasis TX008_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001964494");
        /*"     10 TX009  PIC X(12) VALUE '000001993961'*/
        public StringBasis TX009_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001993961");
        /*"     10 TX010  PIC X(12) VALUE '000002023871'*/
        public StringBasis TX010_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002023871");
        /*"     10 TX011  PIC X(12) VALUE '000002054229'*/
        public StringBasis TX011_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002054229");
        /*"     10 TX012  PIC X(12) VALUE '000002085042'*/
        public StringBasis TX012_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002085042");
        /*"     10 TX001  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX001_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX002  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX002_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX003  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX003_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX004  PIC X(12) VALUE '000001743903'*/
        public StringBasis TX004_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001743903");
        /*"     10 TX005  PIC X(12) VALUE '000001878679'*/
        public StringBasis TX005_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001878679");
        /*"     10 TX006  PIC X(12) VALUE '000001906859'*/
        public StringBasis TX006_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001906859");
        /*"     10 TX007  PIC X(12) VALUE '000001935462'*/
        public StringBasis TX007_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001935462");
        /*"     10 TX008  PIC X(12) VALUE '000001964494'*/
        public StringBasis TX008_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001964494");
        /*"     10 TX009  PIC X(12) VALUE '000001993961'*/
        public StringBasis TX009_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000001993961");
        /*"     10 TX010  PIC X(12) VALUE '000002023871'*/
        public StringBasis TX010_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002023871");
        /*"     10 TX011  PIC X(12) VALUE '000002054229'*/
        public StringBasis TX011_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002054229");
        /*"     10 TX012  PIC X(12) VALUE '000002085042'*/
        public StringBasis TX012_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000002085042");
        /*"     10 TX001  PIC X(12) VALUE '000003568293'*/
        public StringBasis TX001_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003568293");
        /*"     10 TX002  PIC X(12) VALUE '000003568293'*/
        public StringBasis TX002_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003568293");
        /*"     10 TX003  PIC X(12) VALUE '000003568293'*/
        public StringBasis TX003_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003568293");
        /*"     10 TX004  PIC X(12) VALUE '000003568293'*/
        public StringBasis TX004_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003568293");
        /*"     10 TX005  PIC X(12) VALUE '000003844065'*/
        public StringBasis TX005_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003844065");
        /*"     10 TX006  PIC X(12) VALUE '000003901726'*/
        public StringBasis TX006_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003901726");
        /*"     10 TX007  PIC X(12) VALUE '000003960252'*/
        public StringBasis TX007_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000003960252");
        /*"     10 TX008  PIC X(12) VALUE '000004019656'*/
        public StringBasis TX008_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000004019656");
        /*"     10 TX009  PIC X(12) VALUE '000004079950'*/
        public StringBasis TX009_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000004079950");
        /*"     10 TX010  PIC X(12) VALUE '000004141150'*/
        public StringBasis TX010_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000004141150");
        /*"     10 TX011  PIC X(12) VALUE '000004203267'*/
        public StringBasis TX011_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000004203267");
        /*"     10 TX012  PIC X(12) VALUE '000004266316'*/
        public StringBasis TX012_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"000004266316");
        /*"01 TAB-TAXAS-20042005-R REDEFINES TAB-TAXAS-20042005*/
    }
}