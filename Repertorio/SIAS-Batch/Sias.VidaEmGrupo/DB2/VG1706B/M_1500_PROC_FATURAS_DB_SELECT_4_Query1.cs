using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1706B
{
    public class M_1500_PROC_FATURAS_DB_SELECT_4_Query1 : QueryBasis<M_1500_PROC_FATURAS_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PRM_TARIFARIO_IX,
            FATOR_MULTIPLICA
            INTO
            :APOLICOB-PRM-TARIFARIO-IX,
            :APOLICOB-FATOR-MULTIPLICA
            FROM
            SEGUROS.APOLICE_COBERTURAS
            WHERE
            NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND NUM_ITEM = 0
            AND OCORR_HISTORICO = 1
            AND RAMO_COBERTURA = 77
            AND COD_COBERTURA = 0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PRM_TARIFARIO_IX
							,
											FATOR_MULTIPLICA
											FROM
											SEGUROS.APOLICE_COBERTURAS
											WHERE
											NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND NUM_ITEM = 0
											AND OCORR_HISTORICO = 1
											AND RAMO_COBERTURA = 77
											AND COD_COBERTURA = 0";

            return query;
        }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static M_1500_PROC_FATURAS_DB_SELECT_4_Query1 Execute(M_1500_PROC_FATURAS_DB_SELECT_4_Query1 m_1500_PROC_FATURAS_DB_SELECT_4_Query1)
        {
            var ths = m_1500_PROC_FATURAS_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1500_PROC_FATURAS_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1500_PROC_FATURAS_DB_SELECT_4_Query1();
            var i = 0;
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.APOLICOB_FATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}