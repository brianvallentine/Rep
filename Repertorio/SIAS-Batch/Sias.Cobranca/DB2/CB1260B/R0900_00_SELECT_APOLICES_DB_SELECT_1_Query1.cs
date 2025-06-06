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
    public class R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORGAO_EMISSOR
            ,TIPO_SEGURO
            ,TIPO_APOLICE
            INTO :APOLICES-ORGAO-EMISSOR
            ,:APOLICES-TIPO-SEGURO
            ,:APOLICES-TIPO-APOLICE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORGAO_EMISSOR
											,TIPO_SEGURO
											,TIPO_APOLICE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_TIPO_SEGURO { get; set; }
        public string APOLICES_TIPO_APOLICE { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }

        public static R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1 r0900_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r0900_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0900_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.APOLICES_TIPO_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}