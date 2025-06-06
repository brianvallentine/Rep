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
    public class M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1 : QueryBasis<M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(D.VLR_FAIXA_CS_FINAL),
            :WS-VLR-COB-BASICA)
            INTO :WS-MAX-VLR-CONSULTA
            FROM SEGUROS.VG_APOLICE_COB_GAR A,
            SEGUROS.VG_GRUPO_COB_CS_ETARIA B,
            SEGUROS.VG_FAIXA_ETARIA C,
            SEGUROS.VG_FAIXA_CAP_SEGUR D,
            SEGUROS.VG_GARANTIA E,
            SEGUROS.VG_GRUPO_COBERTURA F
            WHERE A.NUM_APOLICE = :WS-NUM-APOLICE-GAR
            AND A.COD_SUBGRUPO = :WS-COD-SUBGRUPO-GAR
            AND A.COD_PRODUTO = :WS-PRODUTO
            AND A.IND_TIPO_COB_GAR = 'PF'
            AND A.IND_PERIODO_FAT = 0
            AND A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA
            AND A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA
            AND A.NUM_GARANTIA = B.NUM_GARANTIA
            AND A.NUM_GARANTIA = E.NUM_GARANTIA
            AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA
            AND B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR
            AND B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(D.VLR_FAIXA_CS_FINAL)
							,
											'{this.WS_VLR_COB_BASICA}')
											FROM SEGUROS.VG_APOLICE_COB_GAR A
							,
											SEGUROS.VG_GRUPO_COB_CS_ETARIA B
							,
											SEGUROS.VG_FAIXA_ETARIA C
							,
											SEGUROS.VG_FAIXA_CAP_SEGUR D
							,
											SEGUROS.VG_GARANTIA E
							,
											SEGUROS.VG_GRUPO_COBERTURA F
											WHERE A.NUM_APOLICE = '{this.WS_NUM_APOLICE_GAR}'
											AND A.COD_SUBGRUPO = '{this.WS_COD_SUBGRUPO_GAR}'
											AND A.COD_PRODUTO = '{this.WS_PRODUTO}'
											AND A.IND_TIPO_COB_GAR = 'PF'
											AND A.IND_PERIODO_FAT = 0
											AND A.SEQ_GRUPO_COBERTURA = B.SEQ_GRUPO_COBERTURA
											AND A.SEQ_GRUPO_COBERTURA = F.SEQ_GRUPO_COBERTURA
											AND A.NUM_GARANTIA = B.NUM_GARANTIA
											AND A.NUM_GARANTIA = E.NUM_GARANTIA
											AND A.DTA_INI_VIGENCIA = B.DTA_INI_VIGENCIA
											AND B.SEQ_FAIXA_CAP_SEGUR = D.SEQ_FAIXA_CAP_SEGUR
											AND B.SEQ_FAIXA_ETARIA = C.SEQ_FAIXA_ETARIA
											WITH UR";

            return query;
        }
        public string WS_MAX_VLR_CONSULTA { get; set; }
        public string WS_COD_SUBGRUPO_GAR { get; set; }
        public string WS_NUM_APOLICE_GAR { get; set; }
        public string WS_VLR_COB_BASICA { get; set; }
        public string WS_PRODUTO { get; set; }

        public static M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1 Execute(M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1 m_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1)
        {
            var ths = m_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0505_LER_MAX_IDADE_VLR_CS_491_DB_SELECT_2_Query1();
            var i = 0;
            dta.WS_MAX_VLR_CONSULTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}