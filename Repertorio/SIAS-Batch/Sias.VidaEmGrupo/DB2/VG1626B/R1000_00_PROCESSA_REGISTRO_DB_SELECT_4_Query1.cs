using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1626B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(OCORR_HISTORICO,0),
            DATE(TIMESTAMP)
            INTO :PROPOVA-OCORR-HISTORICO,
            :WHOST-DATA-HISCOBPR
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND OCORR_HISTORICO =
            (SELECT MAX(T1.OCORR_HISTORICO)
            FROM SEGUROS.HIS_COBER_PROPOST T1
            WHERE T1.NUM_CERTIFICADO =
            :PROPOVA-NUM-CERTIFICADO)
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(OCORR_HISTORICO
							,0)
							,
											DATE(TIMESTAMP)
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND OCORR_HISTORICO =
											(SELECT MAX(T1.OCORR_HISTORICO)
											FROM SEGUROS.HIS_COBER_PROPOST T1
											WHERE T1.NUM_CERTIFICADO =
											'{this.PROPOVA_NUM_CERTIFICADO}')";

            return query;
        }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string WHOST_DATA_HISCOBPR { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

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
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.WHOST_DATA_HISCOBPR = result[i++].Value?.ToString();
            return dta;
        }

    }
}