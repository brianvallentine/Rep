using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0138B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.DATA_INIVIGENCIA
            , B.DATA_TERVIGENCIA
            INTO :V0ENDO-DTINIVIG
            , :V0ENDO-DTTERVIG
            FROM SEGUROS.HIST_CONT_PARCELVA A
            , SEGUROS.ENDOSSOS B
            WHERE A.NUM_CERTIFICADO = :V0HCTB-NRCERTIF
            AND A.NUM_PARCELA = :V0HCTB-NRPARCEL
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND A.COD_OPERACAO BETWEEN 200 AND 299
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
            ORDER BY A.DATA_MOVIMENTO
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.DATA_INIVIGENCIA
											, B.DATA_TERVIGENCIA
											FROM SEGUROS.HIST_CONT_PARCELVA A
											, SEGUROS.ENDOSSOS B
											WHERE A.NUM_CERTIFICADO = '{this.V0HCTB_NRCERTIF}'
											AND A.NUM_PARCELA = '{this.V0HCTB_NRPARCEL}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND A.COD_OPERACAO BETWEEN 200 AND 299
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.NUM_ENDOSSO = B.NUM_ENDOSSO
											ORDER BY A.DATA_MOVIMENTO
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V0HCTB_NRCERTIF { get; set; }
        public string V0HCTB_NRPARCEL { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDO_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}