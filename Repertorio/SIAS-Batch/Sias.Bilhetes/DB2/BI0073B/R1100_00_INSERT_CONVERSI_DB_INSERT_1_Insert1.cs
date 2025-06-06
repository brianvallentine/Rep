using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0073B
{
    public class R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1 : QueryBasis<R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.CONVERSAO_SICOB
            (NUM_PROPOSTA_SIVPF ,
            NUM_SICOB ,
            COD_EMPRESA_SIVPF ,
            COD_PRODUTO_SIVPF ,
            AGEPGTO ,
            DATA_OPERACAO ,
            DATA_QUITACAO ,
            VAL_RCAP ,
            COD_USUARIO ,
            TIMESTAMP)
            VALUES
            (:CONVERSI-NUM-PROPOSTA-SIVPF ,
            :CONVERSI-NUM-SICOB ,
            :CONVERSI-COD-EMPRESA-SIVPF ,
            :CONVERSI-COD-PRODUTO-SIVPF ,
            :CONVERSI-AGEPGTO ,
            :CONVERSI-DATA-OPERACAO ,
            :CONVERSI-DATA-QUITACAO ,
            :CONVERSI-VAL-RCAP ,
            :CONVERSI-COD-USUARIO ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONVERSAO_SICOB (NUM_PROPOSTA_SIVPF , NUM_SICOB , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , AGEPGTO , DATA_OPERACAO , DATA_QUITACAO , VAL_RCAP , COD_USUARIO , TIMESTAMP) VALUES ({FieldThreatment(this.CONVERSI_NUM_PROPOSTA_SIVPF)} , {FieldThreatment(this.CONVERSI_NUM_SICOB)} , {FieldThreatment(this.CONVERSI_COD_EMPRESA_SIVPF)} , {FieldThreatment(this.CONVERSI_COD_PRODUTO_SIVPF)} , {FieldThreatment(this.CONVERSI_AGEPGTO)} , {FieldThreatment(this.CONVERSI_DATA_OPERACAO)} , {FieldThreatment(this.CONVERSI_DATA_QUITACAO)} , {FieldThreatment(this.CONVERSI_VAL_RCAP)} , {FieldThreatment(this.CONVERSI_COD_USUARIO)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string CONVERSI_NUM_SICOB { get; set; }
        public string CONVERSI_COD_EMPRESA_SIVPF { get; set; }
        public string CONVERSI_COD_PRODUTO_SIVPF { get; set; }
        public string CONVERSI_AGEPGTO { get; set; }
        public string CONVERSI_DATA_OPERACAO { get; set; }
        public string CONVERSI_DATA_QUITACAO { get; set; }
        public string CONVERSI_VAL_RCAP { get; set; }
        public string CONVERSI_COD_USUARIO { get; set; }

        public static void Execute(R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1 r1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1)
        {
            var ths = r1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1100_00_INSERT_CONVERSI_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}