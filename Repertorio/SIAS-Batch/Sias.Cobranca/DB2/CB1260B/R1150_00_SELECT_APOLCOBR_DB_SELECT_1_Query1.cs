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
    public class R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 : QueryBasis<R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_COBRANCA
            INTO :APOLCOBR-TIPO-COBRANCA
            FROM SEGUROS.APOLICE_COBRANCA
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_COBRANCA
											FROM SEGUROS.APOLICE_COBRANCA
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string APOLCOBR_TIPO_COBRANCA { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }

        public static R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 Execute(R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 r1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1)
        {
            var ths = r1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1150_00_SELECT_APOLCOBR_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOBR_TIPO_COBRANCA = result[i++].Value?.ToString();
            return dta;
        }

    }
}