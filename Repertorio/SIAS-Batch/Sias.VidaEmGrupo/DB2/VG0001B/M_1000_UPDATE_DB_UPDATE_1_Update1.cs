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
    public class M_1000_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<M_1000_UPDATE_DB_UPDATE_1_Update1>
    {

        private VG0001B_CSOLICITA CurrentOf { get; set; }

        public M_1000_UPDATE_DB_UPDATE_1_Update1(VG0001B_CSOLICITA currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.VG_SOLICITA_FATURA
				SET SIT_SOLICITA =  '{this.VGSOLFAT_SIT_SOLICITA}'
				WHERE
				(
					SIT_SOLICITA = '0' AND DATA_SOLICITACAO > '{this.SISTEMAS_DATA_MOV_6MONTH}' AND NUM_APOLICE NOT IN (SELECT DISTINCT NUM_APOLICE FROM SEGUROS.VG_PRODUTO_SIAS WHERE COD_PRODUTO IN (9329, 9343, 8205, 8209, '{this.JVPRD8205}', '{this.JVPRD8209}', '{this.JVPRD9329}', '{this.JVPRD9343}' ) )
				)
				AND '  ' ) {FieldThreatment(CurrentOf.VGSOLFAT_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string VGSOLFAT_SIT_SOLICITA { get; set; }
        public string SISTEMAS_DATA_MOV_6MONTH { get; set; }
        public string JVPRD8205 { get; set; }
        public string JVPRD8209 { get; set; }
        public string JVPRD9329 { get; set; }
        public string JVPRD9343 { get; set; }

        public static void Execute(M_1000_UPDATE_DB_UPDATE_1_Update1 m_1000_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = m_1000_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}