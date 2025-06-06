using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1 : QueryBasis<R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(DATA_CANCEL_PREV,DATE( '0001-01-01' ))
            INTO :PARCEDEV-DATA-CANCEL-PREV
            FROM SEGUROS.PARCELA_DEVEDOR
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            AND NUM_PARCELA = :PARCELAS-NUM-PARCELA
            AND SITUACAO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(DATA_CANCEL_PREV
							,DATE( '0001-01-01' ))
											FROM SEGUROS.PARCELA_DEVEDOR
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											AND NUM_PARCELA = '{this.PARCELAS_NUM_PARCELA}'
											AND SITUACAO = '1'
											WITH UR";

            return query;
        }
        public string PARCEDEV_DATA_CANCEL_PREV { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1 Execute(R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1 r0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1)
        {
            var ths = r0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0990_00_SELECT_PARCEDEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEDEV_DATA_CANCEL_PREV = result[i++].Value?.ToString();
            return dta;
        }

    }
}