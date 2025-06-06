using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6249B
{
    public class R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1 : QueryBasis<R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SALDO_ATUAL
            INTO :AVISOSAL-SALDO-ATUAL
            FROM SEGUROS.AVISOS_SALDOS
            WHERE AGE_AVISO =
            :AVISOSAL-AGE-AVISO
            AND TIPO_SEGURO =
            :AVISOSAL-TIPO-SEGURO
            AND NUM_AVISO_CREDITO =
            :AVISOSAL-NUM-AVISO-CREDITO
            AND DATA_MOVIMENTO =
            :AVISOSAL-DATA-MOVIMENTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SALDO_ATUAL
											FROM SEGUROS.AVISOS_SALDOS
											WHERE AGE_AVISO =
											'{this.AVISOSAL_AGE_AVISO}'
											AND TIPO_SEGURO =
											'{this.AVISOSAL_TIPO_SEGURO}'
											AND NUM_AVISO_CREDITO =
											'{this.AVISOSAL_NUM_AVISO_CREDITO}'
											AND DATA_MOVIMENTO =
											'{this.AVISOSAL_DATA_MOVIMENTO}'
											WITH UR";

            return query;
        }
        public string AVISOSAL_SALDO_ATUAL { get; set; }
        public string AVISOSAL_NUM_AVISO_CREDITO { get; set; }
        public string AVISOSAL_DATA_MOVIMENTO { get; set; }
        public string AVISOSAL_TIPO_SEGURO { get; set; }
        public string AVISOSAL_AGE_AVISO { get; set; }

        public static R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1 Execute(R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1 r4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1)
        {
            var ths = r4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R4900_LER_AVISOS_SALDOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.AVISOSAL_SALDO_ATUAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}