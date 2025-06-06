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
    public class R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1 : QueryBasis<R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_FORMA_PAGTO_AD
            INTO :AU084-IND-FORMA-PAGTO-AD
            FROM SEGUROS.AU_APOLICE_COMPL
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_FORMA_PAGTO_AD
											FROM SEGUROS.AU_APOLICE_COMPL
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string AU084_IND_FORMA_PAGTO_AD { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }

        public static R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1 Execute(R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1 r0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1)
        {
            var ths = r0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0860_00_LE_TIPO_ADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.AU084_IND_FORMA_PAGTO_AD = result[i++].Value?.ToString();
            return dta;
        }

    }
}