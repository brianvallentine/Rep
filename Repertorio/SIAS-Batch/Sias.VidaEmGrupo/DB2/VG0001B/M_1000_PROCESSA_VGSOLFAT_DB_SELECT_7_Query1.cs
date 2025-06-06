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
    public class M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1 : QueryBasis<M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF,
            NUM_CARTAO_CREDITO
            INTO :VGCOMTRO-NUM-PROPOSTA-SIVPF,
            :VGCOMTRO-NUM-CARTAO-CREDITO
            FROM SEGUROS.VG_COMPL_TERMO
            WHERE NUM_TERMO = :TERMOADE-NUM-TERMO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
							,
											NUM_CARTAO_CREDITO
											FROM SEGUROS.VG_COMPL_TERMO
											WHERE NUM_TERMO = '{this.TERMOADE_NUM_TERMO}'
											WITH UR";

            return query;
        }
        public string VGCOMTRO_NUM_PROPOSTA_SIVPF { get; set; }
        public string VGCOMTRO_NUM_CARTAO_CREDITO { get; set; }
        public string TERMOADE_NUM_TERMO { get; set; }

        public static M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1 Execute(M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1 m_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1)
        {
            var ths = m_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_7_Query1();
            var i = 0;
            dta.VGCOMTRO_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.VGCOMTRO_NUM_CARTAO_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}