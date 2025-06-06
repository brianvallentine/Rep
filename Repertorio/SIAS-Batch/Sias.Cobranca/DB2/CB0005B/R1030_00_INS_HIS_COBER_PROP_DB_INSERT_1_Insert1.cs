using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1 : QueryBasis<R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HIS_COBER_PROPOST VALUES
            (:V0BILH-NUMBIL ,
            1 ,
            :PROPOFID-DTQITBCO ,
            :WS-TER-VIG-HCP ,
            :WS-CPO-VLR-AUX ,
            1 ,
            :WS-CPO-VLR-AUX ,
            106 ,
            :PROPOFID-OPCAO-COBER ,
            :WS-CPO-VLR-AUX ,
            :WS-CPO-VLR-AUX ,
            :WS-CPO-VLR-AUX ,
            0 ,
            0 ,
            0 ,
            :V0BILH-VLRCAP ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            0 ,
            'CB0005B' ,
            CURRENT TIMESTAMP ,
            0 ,
            0 ,
            0 ,
            0 ,
            :V1BILP-CODPRODU ,
            :WS-CPO-SEQ-AUX ,
            NULL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HIS_COBER_PROPOST VALUES ({FieldThreatment(this.V0BILH_NUMBIL)} , 1 , {FieldThreatment(this.PROPOFID_DTQITBCO)} , {FieldThreatment(this.WS_TER_VIG_HCP)} , {FieldThreatment(this.WS_CPO_VLR_AUX)} , 1 , {FieldThreatment(this.WS_CPO_VLR_AUX)} , 106 , {FieldThreatment(this.PROPOFID_OPCAO_COBER)} , {FieldThreatment(this.WS_CPO_VLR_AUX)} , {FieldThreatment(this.WS_CPO_VLR_AUX)} , {FieldThreatment(this.WS_CPO_VLR_AUX)} , 0 , 0 , 0 , {FieldThreatment(this.V0BILH_VLRCAP)} , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 'CB0005B' , CURRENT TIMESTAMP , 0 , 0 , 0 , 0 , {FieldThreatment(this.V1BILP_CODPRODU)} , {FieldThreatment(this.WS_CPO_SEQ_AUX)} , NULL )";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string WS_TER_VIG_HCP { get; set; }
        public string WS_CPO_VLR_AUX { get; set; }
        public string PROPOFID_OPCAO_COBER { get; set; }
        public string V0BILH_VLRCAP { get; set; }
        public string V1BILP_CODPRODU { get; set; }
        public string WS_CPO_SEQ_AUX { get; set; }

        public static void Execute(R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1 r1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1)
        {
            var ths = r1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1030_00_INS_HIS_COBER_PROP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}