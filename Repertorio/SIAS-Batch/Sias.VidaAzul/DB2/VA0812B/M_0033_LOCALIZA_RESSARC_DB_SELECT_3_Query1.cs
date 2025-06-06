using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1 : QueryBasis<M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT C.CODPRODAZ,
            B.DATA_INIVIGENCIA,
            B.DATA_ADMISSAO
            INTO :PROPAZ-CODPRODAZ,
            :V0SEGV-DTINIVIG,
            :V0SEGV-DTRENOVA:V0SEGV-DTRENOVA-I
            FROM SEGUROS.V0RESSARCIAZUL A,
            SEGUROS.V0SEGURAVG B,
            SEGUROS.V0PRODUTOSVG C
            WHERE A.NSAS = :MVCOM-NSAS
            AND A.NSL = :MVCOM-NSL1
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            AND C.NUM_APOLICE = B.NUM_APOLICE
            AND C.CODSUBES = B.COD_SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT C.CODPRODAZ
							,
											B.DATA_INIVIGENCIA
							,
											B.DATA_ADMISSAO
											FROM SEGUROS.V0RESSARCIAZUL A
							,
											SEGUROS.V0SEGURAVG B
							,
											SEGUROS.V0PRODUTOSVG C
											WHERE A.NSAS = '{this.MVCOM_NSAS}'
											AND A.NSL = '{this.MVCOM_NSL1}'
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											AND C.NUM_APOLICE = B.NUM_APOLICE
											AND C.CODSUBES = B.COD_SUBGRUPO
											WITH UR";

            return query;
        }
        public string PROPAZ_CODPRODAZ { get; set; }
        public string V0SEGV_DTINIVIG { get; set; }
        public string V0SEGV_DTRENOVA { get; set; }
        public string V0SEGV_DTRENOVA_I { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL1 { get; set; }

        public static M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1 Execute(M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1 m_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1)
        {
            var ths = m_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0033_LOCALIZA_RESSARC_DB_SELECT_3_Query1();
            var i = 0;
            dta.PROPAZ_CODPRODAZ = result[i++].Value?.ToString();
            dta.V0SEGV_DTINIVIG = result[i++].Value?.ToString();
            dta.V0SEGV_DTRENOVA = result[i++].Value?.ToString();
            dta.V0SEGV_DTRENOVA_I = string.IsNullOrWhiteSpace(dta.V0SEGV_DTRENOVA) ? "-1" : "0";
            return dta;
        }

    }
}