using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0110B
{
    public class P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1 : QueryBasis<P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.HISTORICO_CHEQUES
            ( NUM_CHEQUE_INTERNO
            ,DIG_CHEQUE_INTERNO
            ,DATA_MOVIMENTO
            ,HORA_OPERACAO
            ,COD_OPERACAO
            ,COD_EMPRESA
            ,TIMESTAMP
            ,DATA_COMPENSACAO
            )
            VALUES
            (:HISTOCHE-NUM-CHEQUE-INTERNO
            ,:HISTOCHE-DIG-CHEQUE-INTERNO
            ,:HISTOCHE-DATA-MOVIMENTO
            , CURRENT TIME
            ,:HISTOCHE-COD-OPERACAO
            ,:HISTOCHE-COD-EMPRESA:VIND-CODEMP
            , CURRENT TIMESTAMP
            ,:HISTOCHE-DATA-COMPENSACAO:VIND-DTCOMPE
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.HISTORICO_CHEQUES ( NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,DATA_MOVIMENTO ,HORA_OPERACAO ,COD_OPERACAO ,COD_EMPRESA ,TIMESTAMP ,DATA_COMPENSACAO ) VALUES ({FieldThreatment(this.HISTOCHE_NUM_CHEQUE_INTERNO)} ,{FieldThreatment(this.HISTOCHE_DIG_CHEQUE_INTERNO)} ,{FieldThreatment(this.HISTOCHE_DATA_MOVIMENTO)} , CURRENT TIME ,{FieldThreatment(this.HISTOCHE_COD_OPERACAO)} , {FieldThreatment((this.VIND_CODEMP?.ToInt() == -1 ? null : this.HISTOCHE_COD_EMPRESA))} , CURRENT TIMESTAMP , {FieldThreatment((this.VIND_DTCOMPE?.ToInt() == -1 ? null : this.HISTOCHE_DATA_COMPENSACAO))} )";

            return query;
        }
        public string HISTOCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string HISTOCHE_DIG_CHEQUE_INTERNO { get; set; }
        public string HISTOCHE_DATA_MOVIMENTO { get; set; }
        public string HISTOCHE_COD_OPERACAO { get; set; }
        public string HISTOCHE_COD_EMPRESA { get; set; }
        public string VIND_CODEMP { get; set; }
        public string HISTOCHE_DATA_COMPENSACAO { get; set; }
        public string VIND_DTCOMPE { get; set; }

        public static void Execute(P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1 p22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1)
        {
            var ths = p22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}