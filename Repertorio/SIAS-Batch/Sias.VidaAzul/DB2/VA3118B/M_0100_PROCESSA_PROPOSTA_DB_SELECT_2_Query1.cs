using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3118B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0)
            INTO :WHOST-COD-ERRO-COMUN
            FROM SEGUROS.VG_CRITICA_PROPOSTA T1
            WHERE T1.NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND T1.COD_MSG_CRITICA = 1876
            AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
											FROM SEGUROS.VG_CRITICA_PROPOSTA T1
											WHERE T1.NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND T1.COD_MSG_CRITICA = 1876
											AND T1.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )";

            return query;
        }
        public string WHOST_COD_ERRO_COMUN { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.WHOST_COD_ERRO_COMUN = result[i++].Value?.ToString();
            return dta;
        }

    }
}