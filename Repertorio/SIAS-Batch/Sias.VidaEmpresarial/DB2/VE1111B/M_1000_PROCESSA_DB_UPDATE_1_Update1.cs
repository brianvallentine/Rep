using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE1111B
{
    public class M_1000_PROCESSA_DB_UPDATE_1_Update1 : QueryBasis<M_1000_PROCESSA_DB_UPDATE_1_Update1>
    {

        private VE1111B_CPRODUTOS CurrentOf { get; set; }

        public M_1000_PROCESSA_DB_UPDATE_1_Update1(VE1111B_CPRODUTOS currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PRODUTOS_VG
				SET
				COD_PRODUTO =  '{this.PRODUVG_COD_PRODUTO}',
				NOME_PRODUTO =  '{this.PRODUVG_NOME_PRODUTO}'
				WHERE
				(
					ORIG_PRODU = 'EMPRE' AND COD_SUBGRUPO > 0
				)
				AND NOME_PRODUTO {FieldThreatment(CurrentOf.PRODUVG_NUM_APOLICE, ThreatmentType.InsertWhereField)}
				";

            return query;
        }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }

        public static void Execute(M_1000_PROCESSA_DB_UPDATE_1_Update1 m_1000_PROCESSA_DB_UPDATE_1_Update1)
        {
            var ths = m_1000_PROCESSA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_PROCESSA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}