using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1705B
{
    public class M_1000_CONTINUA_DB_UPDATE_1_Update1 : QueryBasis<M_1000_CONTINUA_DB_UPDATE_1_Update1>
    {

        private VG1705B_AGENCTOAPOL CurrentOf { get; set; }

        public M_1000_CONTINUA_DB_UPDATE_1_Update1(VG1705B_AGENCTOAPOL currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.AGENCTO_APOL_VGAP
				SET NUM_ENDOSSO =  '{this.AGEAPOVG_NUM_ENDOSSO}',
				DATA_MOVIMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				SITUACAO_AGENCTO =  '{this.AGEAPOVG_SITUACAO_AGENCTO}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE
				(
					SITUACAO_AGENCTO = '0'
				)
				AND TIMESTAMP {FieldThreatment(CurrentOf.AGEAPOVG_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string AGEAPOVG_SITUACAO_AGENCTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string AGEAPOVG_NUM_ENDOSSO { get; set; }

        public static void Execute(M_1000_CONTINUA_DB_UPDATE_1_Update1 m_1000_CONTINUA_DB_UPDATE_1_Update1)
        {
            var ths = m_1000_CONTINUA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_CONTINUA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}