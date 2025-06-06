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
    public class M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1 : QueryBasis<M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRCERTIF,
            NRPARCEL,
            VLPRMTOT,
            SITUACAO,
            CODRET,
            OCORRHISTCTA
            INTO :HCTA-NRCERTIF,
            :HCTA-NRPARCEL,
            :HCTA-VLPRMTOT,
            :HCTA-SITUACAO,
            :HCTA-CODRET :VIND-CODRET,
            :HCTA-OCORRHISTCTA
            FROM SEGUROS.V0HISTCONTAVA
            WHERE CODCONV = :WHOST-CODCONV
            AND NSAS = :MVCOM-NSAS
            AND NSL = :MVCOM-NSL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NRCERTIF
							,
											NRPARCEL
							,
											VLPRMTOT
							,
											SITUACAO
							,
											CODRET
							,
											OCORRHISTCTA
											FROM SEGUROS.V0HISTCONTAVA
											WHERE CODCONV = '{this.WHOST_CODCONV}'
											AND NSAS = '{this.MVCOM_NSAS}'
											AND NSL = '{this.MVCOM_NSL}'
											WITH UR";

            return query;
        }
        public string HCTA_NRCERTIF { get; set; }
        public string HCTA_NRPARCEL { get; set; }
        public string HCTA_VLPRMTOT { get; set; }
        public string HCTA_SITUACAO { get; set; }
        public string HCTA_CODRET { get; set; }
        public string VIND_CODRET { get; set; }
        public string HCTA_OCORRHISTCTA { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1 Execute(M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1 m_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1)
        {
            var ths = m_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0035_LOCALIZA_DEVMULTI_DB_SELECT_1_Query1();
            var i = 0;
            dta.HCTA_NRCERTIF = result[i++].Value?.ToString();
            dta.HCTA_NRPARCEL = result[i++].Value?.ToString();
            dta.HCTA_VLPRMTOT = result[i++].Value?.ToString();
            dta.HCTA_SITUACAO = result[i++].Value?.ToString();
            dta.HCTA_CODRET = result[i++].Value?.ToString();
            dta.VIND_CODRET = string.IsNullOrWhiteSpace(dta.HCTA_CODRET) ? "-1" : "0";
            dta.HCTA_OCORRHISTCTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}