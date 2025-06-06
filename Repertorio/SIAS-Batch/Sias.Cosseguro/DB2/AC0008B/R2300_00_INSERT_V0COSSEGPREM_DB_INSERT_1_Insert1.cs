using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0008B
{
    public class R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1 : QueryBasis<R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_PREM
            VALUES (:V0CPRE-COD-EMPR ,
            :V0CPRE-TIPSGU ,
            :V0CPRE-CONGENER ,
            :V0CPRE-NUM-ORDEM ,
            :V0CPRE-NUM-APOL ,
            :V0CPRE-NRENDOS ,
            :V0CPRE-NRPARCEL ,
            :V0CPRE-PRM-TAR-IX ,
            :V0CPRE-VAL-DES-IX ,
            :V0CPRE-OTNPRLIQ ,
            :V0CPRE-OTNADFRA ,
            :V0CPRE-VLCOMISIX ,
            :V0CPRE-OTNTOTAL ,
            :V0CPRE-SITUACAO ,
            :V0CPRE-SIT-CONG ,
            CURRENT TIMESTAMP ,
            :V0CPRE-OCORHIST:VIND-OCR-HIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_PREM VALUES ({FieldThreatment(this.V0CPRE_COD_EMPR)} , {FieldThreatment(this.V0CPRE_TIPSGU)} , {FieldThreatment(this.V0CPRE_CONGENER)} , {FieldThreatment(this.V0CPRE_NUM_ORDEM)} , {FieldThreatment(this.V0CPRE_NUM_APOL)} , {FieldThreatment(this.V0CPRE_NRENDOS)} , {FieldThreatment(this.V0CPRE_NRPARCEL)} , {FieldThreatment(this.V0CPRE_PRM_TAR_IX)} , {FieldThreatment(this.V0CPRE_VAL_DES_IX)} , {FieldThreatment(this.V0CPRE_OTNPRLIQ)} , {FieldThreatment(this.V0CPRE_OTNADFRA)} , {FieldThreatment(this.V0CPRE_VLCOMISIX)} , {FieldThreatment(this.V0CPRE_OTNTOTAL)} , {FieldThreatment(this.V0CPRE_SITUACAO)} , {FieldThreatment(this.V0CPRE_SIT_CONG)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_OCR_HIST?.ToInt() == -1 ? null : this.V0CPRE_OCORHIST))})";

            return query;
        }
        public string V0CPRE_COD_EMPR { get; set; }
        public string V0CPRE_TIPSGU { get; set; }
        public string V0CPRE_CONGENER { get; set; }
        public string V0CPRE_NUM_ORDEM { get; set; }
        public string V0CPRE_NUM_APOL { get; set; }
        public string V0CPRE_NRENDOS { get; set; }
        public string V0CPRE_NRPARCEL { get; set; }
        public string V0CPRE_PRM_TAR_IX { get; set; }
        public string V0CPRE_VAL_DES_IX { get; set; }
        public string V0CPRE_OTNPRLIQ { get; set; }
        public string V0CPRE_OTNADFRA { get; set; }
        public string V0CPRE_VLCOMISIX { get; set; }
        public string V0CPRE_OTNTOTAL { get; set; }
        public string V0CPRE_SITUACAO { get; set; }
        public string V0CPRE_SIT_CONG { get; set; }
        public string V0CPRE_OCORHIST { get; set; }
        public string VIND_OCR_HIST { get; set; }

        public static void Execute(R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1 r2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1)
        {
            var ths = r2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}