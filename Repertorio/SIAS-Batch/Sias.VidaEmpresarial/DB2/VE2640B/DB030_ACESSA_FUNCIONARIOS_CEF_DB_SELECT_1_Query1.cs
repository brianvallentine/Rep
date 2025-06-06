using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1 : QueryBasis<DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            OPERACAO_CONTA,
            NUM_CONTA,
            DIG_CONTA
            INTO :FUNCICEF-COD-AGENCIA,
            :FUNCICEF-OPERACAO-CONTA,
            :FUNCICEF-NUM-CONTA,
            :FUNCICEF-DIG-CONTA
            FROM SEGUROS.FUNCIONARIOS_CEF
            WHERE NUM_MATRICULA = :FUNCICEF-NUM-MATRICULA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											OPERACAO_CONTA
							,
											NUM_CONTA
							,
											DIG_CONTA
											FROM SEGUROS.FUNCIONARIOS_CEF
											WHERE NUM_MATRICULA = '{this.FUNCICEF_NUM_MATRICULA}'";

            return query;
        }
        public string FUNCICEF_COD_AGENCIA { get; set; }
        public string FUNCICEF_OPERACAO_CONTA { get; set; }
        public string FUNCICEF_NUM_CONTA { get; set; }
        public string FUNCICEF_DIG_CONTA { get; set; }
        public string FUNCICEF_NUM_MATRICULA { get; set; }

        public static DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1 Execute(DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1 dB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1)
        {
            var ths = dB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB030_ACESSA_FUNCIONARIOS_CEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.FUNCICEF_COD_AGENCIA = result[i++].Value?.ToString();
            dta.FUNCICEF_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.FUNCICEF_NUM_CONTA = result[i++].Value?.ToString();
            dta.FUNCICEF_DIG_CONTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}