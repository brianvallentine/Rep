using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 : QueryBasis<R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0HISTOPARC
            VALUES (:V0HISP-NUM-APOL ,
            :V0HISP-NRENDOS ,
            :V0HISP-NRPARCEL ,
            :V0HISP-DACPARC ,
            :V0HISP-DTMOVTO ,
            :V0HISP-OPERACAO ,
            :V0HISP-HORAOPER ,
            :V0HISP-OCORHIST ,
            :V0HISP-PRM-TARIFA ,
            :V0HISP-VAL-DESCON ,
            :V0HISP-VLPRMLIQ ,
            :V0HISP-VLADIFRA ,
            :V0HISP-VLCUSEMI ,
            :V0HISP-VLIOCC ,
            :V0HISP-VLPRMTOT ,
            :V0HISP-VLPREMIO ,
            :V0HISP-DTVENCTO ,
            :V0HISP-BCOCOBR ,
            :V0HISP-AGECOBR ,
            :V0HISP-NRAVISO ,
            :V0HISP-NRENDOCA ,
            :V0HISP-SITCONTB ,
            :V0HISP-COD-USUAR ,
            :V0HISP-RNUDOC ,
            :V0HISP-DTQITBCO:VIND-DTQITBCO ,
            :V0HISP-COD-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTOPARC VALUES ({FieldThreatment(this.V0HISP_NUM_APOL)} , {FieldThreatment(this.V0HISP_NRENDOS)} , {FieldThreatment(this.V0HISP_NRPARCEL)} , {FieldThreatment(this.V0HISP_DACPARC)} , {FieldThreatment(this.V0HISP_DTMOVTO)} , {FieldThreatment(this.V0HISP_OPERACAO)} , {FieldThreatment(this.V0HISP_HORAOPER)} , {FieldThreatment(this.V0HISP_OCORHIST)} , {FieldThreatment(this.V0HISP_PRM_TARIFA)} , {FieldThreatment(this.V0HISP_VAL_DESCON)} , {FieldThreatment(this.V0HISP_VLPRMLIQ)} , {FieldThreatment(this.V0HISP_VLADIFRA)} , {FieldThreatment(this.V0HISP_VLCUSEMI)} , {FieldThreatment(this.V0HISP_VLIOCC)} , {FieldThreatment(this.V0HISP_VLPRMTOT)} , {FieldThreatment(this.V0HISP_VLPREMIO)} , {FieldThreatment(this.V0HISP_DTVENCTO)} , {FieldThreatment(this.V0HISP_BCOCOBR)} , {FieldThreatment(this.V0HISP_AGECOBR)} , {FieldThreatment(this.V0HISP_NRAVISO)} , {FieldThreatment(this.V0HISP_NRENDOCA)} , {FieldThreatment(this.V0HISP_SITCONTB)} , {FieldThreatment(this.V0HISP_COD_USUAR)} , {FieldThreatment(this.V0HISP_RNUDOC)} ,  {FieldThreatment((this.VIND_DTQITBCO?.ToInt() == -1 ? null : this.V0HISP_DTQITBCO))} , {FieldThreatment(this.V0HISP_COD_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_DACPARC { get; set; }
        public string V0HISP_DTMOVTO { get; set; }
        public string V0HISP_OPERACAO { get; set; }
        public string V0HISP_HORAOPER { get; set; }
        public string V0HISP_OCORHIST { get; set; }
        public string V0HISP_PRM_TARIFA { get; set; }
        public string V0HISP_VAL_DESCON { get; set; }
        public string V0HISP_VLPRMLIQ { get; set; }
        public string V0HISP_VLADIFRA { get; set; }
        public string V0HISP_VLCUSEMI { get; set; }
        public string V0HISP_VLIOCC { get; set; }
        public string V0HISP_VLPRMTOT { get; set; }
        public string V0HISP_VLPREMIO { get; set; }
        public string V0HISP_DTVENCTO { get; set; }
        public string V0HISP_BCOCOBR { get; set; }
        public string V0HISP_AGECOBR { get; set; }
        public string V0HISP_NRAVISO { get; set; }
        public string V0HISP_NRENDOCA { get; set; }
        public string V0HISP_SITCONTB { get; set; }
        public string V0HISP_COD_USUAR { get; set; }
        public string V0HISP_RNUDOC { get; set; }
        public string V0HISP_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V0HISP_COD_EMPRESA { get; set; }

        public static void Execute(R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 r2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1)
        {
            var ths = r2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2030_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}