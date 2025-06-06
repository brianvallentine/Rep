using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R2241_10_FETCH_DB_SELECT_1_Query1 : QueryBasis<R2241_10_FETCH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.IMP_SEGURADA_IX,
            B.DATA_TERVIGENCIA
            INTO :APOLCOB-IMPSEGURADO,
            :APOLCOB-DT-TERVIGENCIA
            FROM SEGUROS.SEGURADOS_VGAP A,
            SEGUROS.APOLICE_COBERTURAS B
            WHERE A.NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ITEM = B.NUM_ITEM
            AND A.TIPO_SEGURADO = '1'
            AND B.DATA_TERVIGENCIA =
            (SELECT MAX(DATA_TERVIGENCIA)
            FROM SEGUROS.APOLICE_COBERTURAS C
            WHERE C.NUM_APOLICE = B.NUM_APOLICE
            AND C.NUM_ITEM = B.NUM_ITEM)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.IMP_SEGURADA_IX
							,
											B.DATA_TERVIGENCIA
											FROM SEGUROS.SEGURADOS_VGAP A
							,
											SEGUROS.APOLICE_COBERTURAS B
											WHERE A.NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ITEM = B.NUM_ITEM
											AND A.TIPO_SEGURADO = '1'
											AND B.DATA_TERVIGENCIA =
											(SELECT MAX(DATA_TERVIGENCIA)
											FROM SEGUROS.APOLICE_COBERTURAS C
											WHERE C.NUM_APOLICE = B.NUM_APOLICE
											AND C.NUM_ITEM = B.NUM_ITEM)
											WITH UR";

            return query;
        }
        public string APOLCOB_IMPSEGURADO { get; set; }
        public string APOLCOB_DT_TERVIGENCIA { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static R2241_10_FETCH_DB_SELECT_1_Query1 Execute(R2241_10_FETCH_DB_SELECT_1_Query1 r2241_10_FETCH_DB_SELECT_1_Query1)
        {
            var ths = r2241_10_FETCH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2241_10_FETCH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2241_10_FETCH_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCOB_IMPSEGURADO = result[i++].Value?.ToString();
            dta.APOLCOB_DT_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}