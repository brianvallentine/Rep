using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0711S
{
    public class M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1 : QueryBasis<M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IMP_SEGURADA_IX, 0),
            VALUE(PRM_TARIFARIO_IX, 0),
            VALUE(FATOR_MULTIPLICA, 0)
            INTO :APOLICOB-IMP-SEGURADA-IX ,
            :APOLICOB-PRM-TARIFARIO-IX,
            :APOLICOB-FATOR-MULTIPLICA
            FROM SEGUROS.APOLICE_COBERTURAS
            WHERE NUM_APOLICE = :WS-NUM-APOLICE
            AND NUM_ENDOSSO = 0
            AND NUM_ITEM = :SEGURVGA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO
            AND RAMO_COBERTURA IN (:WS-RAMO1, :WS-RAMO2)
            AND COD_COBERTURA = :WS-COBERTURA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(IMP_SEGURADA_IX
							, 0)
							,
											VALUE(PRM_TARIFARIO_IX
							, 0)
							,
											VALUE(FATOR_MULTIPLICA
							, 0)
											FROM SEGUROS.APOLICE_COBERTURAS
											WHERE NUM_APOLICE = '{this.WS_NUM_APOLICE}'
											AND NUM_ENDOSSO = 0
											AND NUM_ITEM = '{this.SEGURVGA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURVGA_OCORR_HISTORICO}'
											AND RAMO_COBERTURA IN ('{this.WS_RAMO1}'
							, '{this.WS_RAMO2}')
											AND COD_COBERTURA = '{this.WS_COBERTURA}'
											WITH UR";

            return query;
        }
        public string APOLICOB_IMP_SEGURADA_IX { get; set; }
        public string APOLICOB_PRM_TARIFARIO_IX { get; set; }
        public string APOLICOB_FATOR_MULTIPLICA { get; set; }
        public string SEGURVGA_OCORR_HISTORICO { get; set; }
        public string SEGURVGA_NUM_ITEM { get; set; }
        public string WS_NUM_APOLICE { get; set; }
        public string WS_COBERTURA { get; set; }
        public string WS_RAMO1 { get; set; }
        public string WS_RAMO2 { get; set; }

        public static M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1 Execute(M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1 m_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = m_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1300_SELECT_APOL_COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.APOLICOB_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.APOLICOB_FATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}