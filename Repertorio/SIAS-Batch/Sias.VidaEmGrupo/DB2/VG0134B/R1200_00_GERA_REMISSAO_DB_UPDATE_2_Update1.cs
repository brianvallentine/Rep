using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0134B
{
    public class R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1 : QueryBasis<R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1>
    {

        private VG0134B_CRELAT CurrentOf { get; set; }

        public R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1(VG0134B_CRELAT currentOf)
        {
            CurrentOf = currentOf;
        }

        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE
				(
					COD_RELATORIO = 'VG0134B' AND SIT_REGISTRO = '0'
				)
				AND COD_PLANO {FieldThreatment(CurrentOf.RELATORI_ANO_REFERENCIA, ThreatmentType.InsertWhereField)}
				";

            return query;
        }

        public static void Execute(R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1 r1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1)
        {
            var ths = r1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_GERA_REMISSAO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}