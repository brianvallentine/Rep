using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI2010B
{
    public class R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_EMISSAO, DAY(DATA_EMISSAO)
            INTO :CHEQUEMI-DATA-EMISSAO
            ,:WS-DIA-DT-EMISSAO
            FROM SEGUROS.CHEQUES_EMITIDOS
            WHERE NUM_CHEQUE_INTERNO = :SISINCHE-NUM-CHEQUE-INTERNO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_EMISSAO
							, DAY(DATA_EMISSAO)
											FROM SEGUROS.CHEQUES_EMITIDOS
											WHERE NUM_CHEQUE_INTERNO = '{this.SISINCHE_NUM_CHEQUE_INTERNO}'
											WITH UR";

            return query;
        }
        public string CHEQUEMI_DATA_EMISSAO { get; set; }
        public string WS_DIA_DT_EMISSAO { get; set; }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }

        public static R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0612_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.CHEQUEMI_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.WS_DIA_DT_EMISSAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}