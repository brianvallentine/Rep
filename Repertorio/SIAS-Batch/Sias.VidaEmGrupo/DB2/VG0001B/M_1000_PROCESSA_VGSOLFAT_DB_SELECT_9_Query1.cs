using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1 : QueryBasis<M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(B.VLR_PREMIO),0),
            VALUE(SUM(B.IMP_SEGURADA),0),
            VALUE(COUNT(*),0)
            INTO :VGFUNCOB-VLR-PREMIO,
            :VGFUNCOB-IMP-SEGURADA,
            :VGFUNCOB-QTD-VIDAS
            FROM SEGUROS.VG_MOV_FUNCIONARIO A,
            SEGUROS.VG_FUNC_COBERTURA B
            WHERE A.NUM_PROPOSTA_SIVPF =
            :VGCOMTRO-NUM-PROPOSTA-SIVPF
            AND A.STA_FUNCIONARIO IN ( 'L' , 'E' )
            AND A.DTH_FIM_VIGENCIA = '9999-12-31'
            AND B.NUM_PROPOSTA_SIVPF = A.NUM_PROPOSTA_SIVPF
            AND B.NUM_CPF = A.NUM_CPF
            AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA
            AND B.COD_GARANTIA = 17
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(B.VLR_PREMIO)
							,0)
							,
											VALUE(SUM(B.IMP_SEGURADA)
							,0)
							,
											VALUE(COUNT(*)
							,0)
											FROM SEGUROS.VG_MOV_FUNCIONARIO A
							,
											SEGUROS.VG_FUNC_COBERTURA B
											WHERE A.NUM_PROPOSTA_SIVPF =
											'{this.VGCOMTRO_NUM_PROPOSTA_SIVPF}'
											AND A.STA_FUNCIONARIO IN ( 'L' 
							, 'E' )
											AND A.DTH_FIM_VIGENCIA = '9999-12-31'
											AND B.NUM_PROPOSTA_SIVPF = A.NUM_PROPOSTA_SIVPF
											AND B.NUM_CPF = A.NUM_CPF
											AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA
											AND B.COD_GARANTIA = 17
											WITH UR";

            return query;
        }
        public string VGFUNCOB_VLR_PREMIO { get; set; }
        public string VGFUNCOB_IMP_SEGURADA { get; set; }
        public string VGFUNCOB_QTD_VIDAS { get; set; }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }

        public static M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1 Execute(M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1 m_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1)
        {
            var ths = m_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_9_Query1();
            var i = 0;
            dta.VGFUNCOB_VLR_PREMIO = result[i++].Value?.ToString();
            dta.VGFUNCOB_IMP_SEGURADA = result[i++].Value?.ToString();
            dta.VGFUNCOB_QTD_VIDAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}