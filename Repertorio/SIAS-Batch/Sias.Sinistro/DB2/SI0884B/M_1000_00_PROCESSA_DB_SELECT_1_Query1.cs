using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0884B
{
    public class M_1000_00_PROCESSA_DB_SELECT_1_Query1 : QueryBasis<M_1000_00_PROCESSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT U.NOME_USUARIO
            INTO :USUARIOS-NOME-USUARIO
            FROM SEGUROS.SI_ANALISTA_RODIZI E,
            SEGUROS.USUARIOS U
            WHERE E.COD_FONTE = :SISINACO-COD-FONTE
            AND E.NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND E.DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            AND U.COD_USUARIO = E.COD_USUARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT U.NOME_USUARIO
											FROM SEGUROS.SI_ANALISTA_RODIZI E
							,
											SEGUROS.USUARIOS U
											WHERE E.COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND E.NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND E.DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'
											AND U.COD_USUARIO = E.COD_USUARIO";

            return query;
        }
        public string USUARIOS_NOME_USUARIO { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

        public static M_1000_00_PROCESSA_DB_SELECT_1_Query1 Execute(M_1000_00_PROCESSA_DB_SELECT_1_Query1 m_1000_00_PROCESSA_DB_SELECT_1_Query1)
        {
            var ths = m_1000_00_PROCESSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_00_PROCESSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_00_PROCESSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.USUARIOS_NOME_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}