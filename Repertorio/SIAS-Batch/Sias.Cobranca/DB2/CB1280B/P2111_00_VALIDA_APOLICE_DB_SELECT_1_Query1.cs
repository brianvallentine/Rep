using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1280B
{
    public class P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1 : QueryBasis<P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ENDOSSO
            ,NUM_PARCELA
            INTO :CBAPOVIG-NUM-ENDOSSO
            ,:CBAPOVIG-NUM-PARCELA
            FROM SEGUROS.CB_APOLICE_VIGPROP
            WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_ENDOSSO
											,NUM_PARCELA
											FROM SEGUROS.CB_APOLICE_VIGPROP
											WHERE NUM_APOLICE = '{this.PARCEHIS_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string CBAPOVIG_NUM_ENDOSSO { get; set; }
        public string CBAPOVIG_NUM_PARCELA { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }

        public static P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1 Execute(P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1 p2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = p2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBAPOVIG_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.CBAPOVIG_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}