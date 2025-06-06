using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0503B
{
    public class R100_INSERT_BANCO_DB_INSERT_1_Insert1 : QueryBasis<R100_INSERT_BANCO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO ODS.OD_PESS_CONTA_BANC
            ( NUM_PESSOA ,
            SEQ_CONTA_BANCARIA,
            DTH_CADASTRAMENTO ,
            STA_CONTA ,
            COD_BANCO ,
            COD_AGENCIA ,
            IND_CONTA_BANCARIA,
            NUM_CONTA ,
            NUM_DV_CONTA ,
            NUM_OPERACAO_CONTA)
            VALUES (:OD009-NUM-PESSOA ,
            :OD009-SEQ-CONTA-BANCARIA,
            :OD009-DTH-CADASTRAMENTO ,
            :OD009-STA-CONTA ,
            :OD009-COD-BANCO ,
            :OD009-COD-AGENCIA ,
            :OD009-IND-CONTA-BANCARIA,
            :OD009-NUM-CONTA ,
            :OD009-NUM-DV-CONTA:VIND-NULL01 ,
            :OD009-NUM-OPERACAO-CONTA:VIND-NULL02)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO ODS.OD_PESS_CONTA_BANC ( NUM_PESSOA , SEQ_CONTA_BANCARIA, DTH_CADASTRAMENTO , STA_CONTA , COD_BANCO , COD_AGENCIA , IND_CONTA_BANCARIA, NUM_CONTA , NUM_DV_CONTA , NUM_OPERACAO_CONTA) VALUES ({FieldThreatment(this.OD009_NUM_PESSOA)} , {FieldThreatment(this.OD009_SEQ_CONTA_BANCARIA)}, {FieldThreatment(this.OD009_DTH_CADASTRAMENTO)} , {FieldThreatment(this.OD009_STA_CONTA)} , {FieldThreatment(this.OD009_COD_BANCO)} , {FieldThreatment(this.OD009_COD_AGENCIA)} , {FieldThreatment(this.OD009_IND_CONTA_BANCARIA)}, {FieldThreatment(this.OD009_NUM_CONTA)} ,  {FieldThreatment((this.VIND_NULL01?.ToInt() == -1 ? null : this.OD009_NUM_DV_CONTA))} ,  {FieldThreatment((this.VIND_NULL02?.ToInt() == -1 ? null : this.OD009_NUM_OPERACAO_CONTA))})";

            return query;
        }
        public string OD009_NUM_PESSOA { get; set; }
        public string OD009_SEQ_CONTA_BANCARIA { get; set; }
        public string OD009_DTH_CADASTRAMENTO { get; set; }
        public string OD009_STA_CONTA { get; set; }
        public string OD009_COD_BANCO { get; set; }
        public string OD009_COD_AGENCIA { get; set; }
        public string OD009_IND_CONTA_BANCARIA { get; set; }
        public string OD009_NUM_CONTA { get; set; }
        public string OD009_NUM_DV_CONTA { get; set; }
        public string VIND_NULL01 { get; set; }
        public string OD009_NUM_OPERACAO_CONTA { get; set; }
        public string VIND_NULL02 { get; set; }

        public static void Execute(R100_INSERT_BANCO_DB_INSERT_1_Insert1 r100_INSERT_BANCO_DB_INSERT_1_Insert1)
        {
            var ths = r100_INSERT_BANCO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R100_INSERT_BANCO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}