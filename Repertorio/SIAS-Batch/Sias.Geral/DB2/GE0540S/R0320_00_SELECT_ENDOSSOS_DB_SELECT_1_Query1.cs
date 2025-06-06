using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0540S
{
    public class R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCORR_ENDERECO ,
            RAMO_EMISSOR ,
            COD_PRODUTO
            INTO :ENDOSSOS-OCORR-ENDERECO ,
            :ENDOSSOS-RAMO-EMISSOR ,
            :ENDOSSOS-COD-PRODUTO
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCORR_ENDERECO 
							,
											RAMO_EMISSOR 
							,
											COD_PRODUTO
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											WITH UR";

            return query;
        }
        public string ENDOSSOS_OCORR_ENDERECO { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string ENDOSSOS_COD_PRODUTO { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 Execute(R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 r0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.ENDOSSOS_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.ENDOSSOS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}