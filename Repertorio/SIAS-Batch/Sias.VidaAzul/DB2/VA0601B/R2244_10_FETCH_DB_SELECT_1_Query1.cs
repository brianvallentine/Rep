using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2244_10_FETCH_DB_SELECT_1_Query1 : QueryBasis<R2244_10_FETCH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.IMP_SEGURADA_IX,
            B.DATA_TERVIGENCIA
            INTO :APOLCOB-IMPSEGURADO,
            :APOLCOB-DT-TERVIGENCIA
            FROM SEGUROS.ENDOSSOS A,
            SEGUROS.APOLICE_COBERTURAS B
            WHERE A.NUM_APOLICE = :BILHETE-NUM-APOLICE
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
            AND A.DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO
            AND A.DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.IMP_SEGURADA_IX
							,
											B.DATA_TERVIGENCIA
											FROM SEGUROS.ENDOSSOS A
							,
											SEGUROS.APOLICE_COBERTURAS B
											WHERE A.NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NUM_ENDOSSO
											AND A.DATA_INIVIGENCIA <= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											AND A.DATA_TERVIGENCIA >= '{this.SISTEMAS_DATA_MOV_ABERTO}'
											WITH UR";

            return query;
        }
        public string APOLCOB_IMPSEGURADO { get; set; }
        public string APOLCOB_DT_TERVIGENCIA { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R2244_10_FETCH_DB_SELECT_1_Query1 Execute(R2244_10_FETCH_DB_SELECT_1_Query1 r2244_10_FETCH_DB_SELECT_1_Query1)
        {
            var ths = r2244_10_FETCH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2244_10_FETCH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2244_10_FETCH_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOB_IMPSEGURADO = result[i++].Value?.ToString();
            dta.APOLCOB_DT_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}