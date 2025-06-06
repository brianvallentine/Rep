using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 : QueryBasis<R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTOPARC
            VALUES (:V1HIST-NUM-APOL ,
            :V1HIST-NRENDOS ,
            :V1HIST-NRPARCEL ,
            :V1HIST-DACPARC ,
            :V1HIST-DTMOVTO ,
            :V1HIST-OPERACAO ,
            CURRENT TIME ,
            :V1HIST-OCORHIST ,
            :V2HIST-PRM-TARIF ,
            :V2HIST-DESCONTO ,
            :V2HIST-VLPRMLIQ ,
            :V2HIST-VLADIFRA ,
            :V2HIST-VLCUSEMI ,
            :V2HIST-VLIOCC ,
            :V2HIST-VLPRMTOT ,
            :V2HIST-VLPREMIO ,
            :V1HIST-DTVENCTO ,
            :V1HIST-BCOCOBR ,
            :V1HIST-AGECOBR ,
            :V1HIST-NRAVISO ,
            :V1HIST-NRENDOCA ,
            :V1HIST-SITCONTB ,
            :V1HIST-USUARIO ,
            :V1HIST-RNUDOC ,
            :V1HIST-DTQITBCO ,
            :V1HIST-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTOPARC VALUES ({FieldThreatment(this.V1HIST_NUM_APOL)} , {FieldThreatment(this.V1HIST_NRENDOS)} , {FieldThreatment(this.V1HIST_NRPARCEL)} , {FieldThreatment(this.V1HIST_DACPARC)} , {FieldThreatment(this.V1HIST_DTMOVTO)} , {FieldThreatment(this.V1HIST_OPERACAO)} , CURRENT TIME , {FieldThreatment(this.V1HIST_OCORHIST)} , {FieldThreatment(this.V2HIST_PRM_TARIF)} , {FieldThreatment(this.V2HIST_DESCONTO)} , {FieldThreatment(this.V2HIST_VLPRMLIQ)} , {FieldThreatment(this.V2HIST_VLADIFRA)} , {FieldThreatment(this.V2HIST_VLCUSEMI)} , {FieldThreatment(this.V2HIST_VLIOCC)} , {FieldThreatment(this.V2HIST_VLPRMTOT)} , {FieldThreatment(this.V2HIST_VLPREMIO)} , {FieldThreatment(this.V1HIST_DTVENCTO)} , {FieldThreatment(this.V1HIST_BCOCOBR)} , {FieldThreatment(this.V1HIST_AGECOBR)} , {FieldThreatment(this.V1HIST_NRAVISO)} , {FieldThreatment(this.V1HIST_NRENDOCA)} , {FieldThreatment(this.V1HIST_SITCONTB)} , {FieldThreatment(this.V1HIST_USUARIO)} , {FieldThreatment(this.V1HIST_RNUDOC)} , {FieldThreatment(this.V1HIST_DTQITBCO)} , {FieldThreatment(this.V1HIST_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V1HIST_NUM_APOL { get; set; }
        public string V1HIST_NRENDOS { get; set; }
        public string V1HIST_NRPARCEL { get; set; }
        public string V1HIST_DACPARC { get; set; }
        public string V1HIST_DTMOVTO { get; set; }
        public string V1HIST_OPERACAO { get; set; }
        public string V1HIST_OCORHIST { get; set; }
        public string V2HIST_PRM_TARIF { get; set; }
        public string V2HIST_DESCONTO { get; set; }
        public string V2HIST_VLPRMLIQ { get; set; }
        public string V2HIST_VLADIFRA { get; set; }
        public string V2HIST_VLCUSEMI { get; set; }
        public string V2HIST_VLIOCC { get; set; }
        public string V2HIST_VLPRMTOT { get; set; }
        public string V2HIST_VLPREMIO { get; set; }
        public string V1HIST_DTVENCTO { get; set; }
        public string V1HIST_BCOCOBR { get; set; }
        public string V1HIST_AGECOBR { get; set; }
        public string V1HIST_NRAVISO { get; set; }
        public string V1HIST_NRENDOCA { get; set; }
        public string V1HIST_SITCONTB { get; set; }
        public string V1HIST_USUARIO { get; set; }
        public string V1HIST_RNUDOC { get; set; }
        public string V1HIST_DTQITBCO { get; set; }
        public string V1HIST_EMPRESA { get; set; }

        public static void Execute(R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 r1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1)
        {
            var ths = r1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}