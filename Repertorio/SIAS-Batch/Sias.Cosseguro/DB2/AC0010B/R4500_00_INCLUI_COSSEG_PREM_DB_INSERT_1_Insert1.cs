using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0010B
{
    public class R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1 : QueryBasis<R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSSEG_PREM
            VALUES (:V2CPRE-COD-EMPR ,
            :V2CPRE-TIPSGU ,
            :V2CPRE-CONGENER ,
            :V2CPRE-NUM-ORDEM ,
            :V2CPRE-NUM-APOL ,
            :V2CPRE-NRENDOS ,
            :V2CPRE-NRPARCEL ,
            :V2CPRE-PRM-TAR-IX ,
            :V2CPRE-VAL-DES-IX ,
            :V2CPRE-OTNPRLIQ ,
            :V2CPRE-OTNADFRA ,
            :V2CPRE-VLCOMISIX ,
            :V2CPRE-OTNTOTAL ,
            :V2CPRE-SITUACAO ,
            :V2CPRE-SIT-CONG ,
            CURRENT TIMESTAMP ,
            :V2CPRE-OCORHIST:VIND-OCR-HIST)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSSEG_PREM VALUES ({FieldThreatment(this.V2CPRE_COD_EMPR)} , {FieldThreatment(this.V2CPRE_TIPSGU)} , {FieldThreatment(this.V2CPRE_CONGENER)} , {FieldThreatment(this.V2CPRE_NUM_ORDEM)} , {FieldThreatment(this.V2CPRE_NUM_APOL)} , {FieldThreatment(this.V2CPRE_NRENDOS)} , {FieldThreatment(this.V2CPRE_NRPARCEL)} , {FieldThreatment(this.V2CPRE_PRM_TAR_IX)} , {FieldThreatment(this.V2CPRE_VAL_DES_IX)} , {FieldThreatment(this.V2CPRE_OTNPRLIQ)} , {FieldThreatment(this.V2CPRE_OTNADFRA)} , {FieldThreatment(this.V2CPRE_VLCOMISIX)} , {FieldThreatment(this.V2CPRE_OTNTOTAL)} , {FieldThreatment(this.V2CPRE_SITUACAO)} , {FieldThreatment(this.V2CPRE_SIT_CONG)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_OCR_HIST?.ToInt() == -1 ? null : this.V2CPRE_OCORHIST))})";

            return query;
        }
        public string V2CPRE_COD_EMPR { get; set; }
        public string V2CPRE_TIPSGU { get; set; }
        public string V2CPRE_CONGENER { get; set; }
        public string V2CPRE_NUM_ORDEM { get; set; }
        public string V2CPRE_NUM_APOL { get; set; }
        public string V2CPRE_NRENDOS { get; set; }
        public string V2CPRE_NRPARCEL { get; set; }
        public string V2CPRE_PRM_TAR_IX { get; set; }
        public string V2CPRE_VAL_DES_IX { get; set; }
        public string V2CPRE_OTNPRLIQ { get; set; }
        public string V2CPRE_OTNADFRA { get; set; }
        public string V2CPRE_VLCOMISIX { get; set; }
        public string V2CPRE_OTNTOTAL { get; set; }
        public string V2CPRE_SITUACAO { get; set; }
        public string V2CPRE_SIT_CONG { get; set; }
        public string V2CPRE_OCORHIST { get; set; }
        public string VIND_OCR_HIST { get; set; }

        public static void Execute(R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1 r4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1)
        {
            var ths = r4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4500_00_INCLUI_COSSEG_PREM_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}